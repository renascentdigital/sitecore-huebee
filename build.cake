
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var buildDir = Directory("./src/bin") + Directory(configuration);

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./Sitecore.Huebee.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    MSBuild("./Sitecore.Huebee.sln", settings =>
        settings.SetConfiguration(configuration));
    
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{

});

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

RunTarget(target);
