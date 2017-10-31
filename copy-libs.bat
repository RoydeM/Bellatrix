@echo off
copy Bellatrix.Services.Logger.ConsoleLogger\bin\Debug\Bellatrix.Services.Logger.ConsoleLogger.* Lib
copy Bellatrix.Services.Logger.FileLogger\bin\Debug\Bellatrix.Services.Logger.FileLogger.* Lib
copy Bellatrix.Infrastructure.AdoNetRepository\bin\Debug\Bellatrix.Infrastructure.AdoNetRepository.* Lib
copy Bellatrix.Services.Logger.DbLogger\bin\Debug\Bellatrix.Services.Logger.DbLogger.* Lib
pause