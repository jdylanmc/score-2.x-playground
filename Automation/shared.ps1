function DetectSitecore()
{
    Write-Host "Detecting Sitecore..."

    if (!(Test-Path ".\sandbox\Website\bin\Sitecore.Kernel.dll"))
    {
        throw "No Sitecore detected in the .\sandbox. Please first install Sitecore and then run the setup wizard again"
    }

    (Get-Item .\sandbox\Website\bin\Sitecore.Kernel.dll | Select -ExpandProperty VersionInfo).ProductVersion -match '^(\d\.\d)\.?\d? rev. (\d+)$' | Out-Null

    $version = $matches[1]
    $revision = $matches[2]

    Write-Host "Detected $version.$revision"

    Return @{"Version"="$version"; "Revision"="$revision"}
}
