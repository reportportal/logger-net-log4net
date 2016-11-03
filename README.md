[![Build status](https://ci.appveyor.com/api/projects/status/649dujaserywuchy?svg=true)](https://ci.appveyor.com/project/nvborisenko/logger-net-log4net)

# Installation

Install **ReportPortal.Log4Net** NuGet package.

[![NuGet version](https://badge.fury.io/nu/reportportal.log4net.svg)](https://badge.fury.io/nu/reportportal.log4net)


> PS> Install-Package ReportPortal.Log4Net

# Configuration

Add custom appender into log4net configuration file.
```xml
<log4net>
  ...
  <appender name="RP" type="ReportPortal.ReportPortalAppender, ReportPortal.Log4Net">
    <layout type="log4net.Layout.SimpleLayout" />
    <layout type="log4net.Layout.PatternLayout">
      <conversionpattern value="%message%newline" />
    </layout>
  </appender>
  ...
</log4net>
```

Specify reference to appender in the root section.
```xml
<log4net>
  ...
  <root>
      ...
      <appender-ref ref="RP" />
      ...
  </root>
  ...
</log4net>
```
