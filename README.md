# Introduction 
This is a simple launcher to start any number of apps and/or URLs, either using the mouse or a number between 1 and 9.

# Configuration
The only configuration is in a file called GuidosLauncher.xml, which must be located in the same dir as the executable:

``` xml
<?xml version="1.0" encoding="utf-8" ?>
<programs>
  <program>
    <label>Launch Kodi</label>
    <path>C:\Program Files (x86)\Kodi\Kodi.exe</path>
    <arguments></arguments>
  </program>
  <program>
    <label>Netflix</label>
    <path>http://www.netflix.com</path>
    <arguments></arguments>
  </program>
  <program>
    <label>Chrome</label>
    <path>%LOCALAPPDATA%\Google\Chrome\Application\chrome.exe</path>
    <arguments></arguments>
  </program>
  <program>
    <label>Spotify (in Internet Explorer)</label>
    <path>iexplore</path>
    <arguments>http://www.spotify.com</arguments>
  </program>
</programs>

```

# Installation
The executable can be copied and run from anywhere. The only requirement is the .NET Framework 4 Client Profile.
