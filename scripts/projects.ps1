. ".\environment.ps1"

class Project {
    $name
    $path
    $solutionFile
    $testProjectFile

    Project($name, $path, $solutionFile) {
        $this.name = $name
        $this.path = $path
        $this.solutionFile = "$path\$solutionFile"
        $this.testProjectFile = "$path\TestProject.csproj"
    }
}

$omnis = [Project]::new("MyLibrary", "$baseDir\source", "Omnis.sln")

$projects = $omnis