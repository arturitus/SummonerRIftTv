SETLOCAL enableextensions enabledelayedexpansion
@echo off

set RADS_PATH=%1


echo "" "League of Legends.exe" "spectator spectator.%5.lol.pvp.net:8080 %2 %3 %4" "-UseRads" "-GameBaseDir=.."
if exist "%RADS_PATH%\Game" (
	cd /d "!RADS_PATH!\Config"
	for /F "delims=" %%a in ('find "        locale: " LeagueClientSettings.yaml') do set "locale=%%a"
	for /F "tokens=2 delims=: " %%a in ("!locale!") do set "locale=%%a"

	SET RADS_PATH="!RADS_PATH!\Game"
	@cd /d !RADS_PATH!
	
	if exist "League of Legends.exe" (
		NET STOP vgc >NUL 2>NUL
		NET STOP vgk >NUL 2>NUL
		@start "" "League of Legends.exe" "spectator spectator.%5.lol.pvp.net:8080 %2 %3 %4" "-UseRads" "-GameBaseDir=.."
		NET START vgk >NUL 2>NUL
		NET START vgc >NUL 2>NUL
		TIMEOUT /T 3
		goto :eof
	)
)

if exist "%RADS_PATH%\RADS" (
	SET RADS_PATH="!RADS_PATH!\RADS"
	@cd /d !RADS_PATH!

	@cd /d "!RADS_PATH!\projects"
	for /d %%D in (league_client_*) do (
	    for /F "tokens=3,4 delims=_ " %%a in ("%%~nxD") do (
	        set locale=%%a_%%b
	    )
	)

	for /l %%a in (1,1,100) do if "!RADS_PATH:~-1!"==" " set RADS_PATH=!RADS_PATH:~0,-1!
	@cd /d "!RADS_PATH!\solutions\lol_game_client_sln\releases"

	set /a v0=0, v1=0, v2=0, v3=0
	set init=0
	for /d %%A in ("!RADS_PATH!\solutions\lol_game_client_sln\releases\*") do (
		set currentDirectory=%%~nxA

		for /F "tokens=1,2,3,4 delims=." %%i in ("!currentDirectory!") do (
			set /a test=%%i*1, test2=%%j*1, test3=%%k*1, test4=%%l*1

			if !init! equ 0 (
				set /a init=1, flag=1
			) else (
				set flag=0

				if !test! gtr !v0! (
					set flag=1
				) else (
					if !test2! gtr !v1! (
						set flag=1
					) else (
						if !test3! gtr !v2! (
							set flag=1
						) else (
							if !test4! gtr !v3! (
								set flag=1
							)
						)
					)
				)
			)

			if !flag! gtr 0 (
				set /a v0=!test!, v1=!test2!, v2=!test3!, v3=!test4!
			)
		)
	)

	if !init! equ 0 goto cannotFind
	set lolver=!v0!.!v1!.!v2!.!v3!

	@cd /d "!RADS_PATH!\solutions\lol_game_client_sln\releases\!lolver!\deploy"
	if exist "League of Legends.exe" (
		NET STOP vgc >NUL 2>NUL
		NET STOP vgk >NUL 2>NUL
		@start "" "League of Legends.exe" "spectator spectator.%5.lol.pvp.net:8080 %2 %3 %4" "-UseRads" "-SkipBuild" "-GameBaseDir=.."
		NET START vgk >NUL 2>NUL
		NET START vgc >NUL 2>NUL
		TIMEOUT /T 3
		goto :eof
	)
)

echo ===================
echo KR: LOL
echo EN: Cannot found LOL directory path for automatic. Please see our spectate help page: http://www.op.gg/help/observer
echo ===================
@pause

:eof
