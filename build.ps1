function Get-SolutionConfigurations($solution)
{
        Get-Content $solution |
        Where-Object {$_ -match "(?<config>\w+)\|"} |
        %{ $($Matches['config'])} |
        select -uniq
}


$buildScriptPath=$PSScriptRoot
$projectName="SeleniumSauceLabsPOC"
$solutionPath="$buildScriptPath\.."
$solution="$solutionPath\$projectName.sln"
$csprojPath="$buildScriptPath\..\$projectName"
$csproj="$csprojPath\$projectName.csproj"
$msbuild="C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
$nunitPath="$buildScriptPath\..\packages\NUnit.ConsoleRunner.3.5.0\tools\nunit3-console.exe"
$tunnel="$solutionPath\SauceLabsConnect\bin\sc.exe"


Write-Host "Build"
@(Get-SolutionConfigurations $solution) | foreach {
	Write-Host " - $_"
    & $msbuild $csproj /p:Configuration=$_ /nologo /verbosity:quiet
}

Write-Host "Start Local"
& $tunnel 


Write-Host "Run Tests"
@(Get-SolutionConfigurations $solution)| foreach {
	if ($_ -ne "Debug" -And $_ -ne "Release") {
	Write-Host " - $_"
    Start-Job -Name $_ -ScriptBlock {
        param($configuration,$nunit,$solutionPath,$csprojPath,$projectName)
        & $nunit --result:$solutionPath\nunit_$configuration.xml --config:$configuration $csprojPath\bin\$configuration\$projectName.dll
    } -ArgumentList $_, $nunitPath,$solutionPath,$csprojPath,$projectName
}}
Get-Job | Wait-Job
Get-Job | Receive-Job
