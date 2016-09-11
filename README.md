# staffdb
My Playground for Owin, Swagger, IdentifyServer samples. 


1. Topshelf
Octopus.Standlone.exe install
Octopus.Standlone.exe uninstall
Octopus.Standlone.exe start
Octopus.Standlone.exe stop

Addition Info:
http://docs.topshelf-project.com/en/latest/overview/commandline.html#examples
MyService.exe install -username:DOMAINServiceAccount -password:itsASecret -servicename:AwesomeService –autostart

2. Swagger:
Install-Package Swashbuckle.Core
http://localhost:6060/swagger/ui/index

3. Oauth
curl http://localhost:6060/token -d "grant_type=password&username=user&password=user"
{"access_token":"AQAAANCMnd8BFdERjHoAwE_Cl-sBAAAAqHb0qtgH9kellh2kmjYY0gAAAAACAAAAAAADZgAAwAAAABAAAADxCCTIZLbVwdc03NWQwX0lAAAAAASAAACgAAAAEAAAADvwYrMXALrACXLjqG7DC3Z4AAAAisA6L0F2lEM4Jr62FybWbEBALz5rwsd8PHVjgHmeu-Ja1tetuAL6qVSnxVw0Vn-UQcV1HqDJuEZ0_G6ToH9iM3B6Dqvajd6q2LS5kuzgqtmFaX5A47NU_vGNFQY1zuOyMhQ0Z2ZpaTp1T_VuZBvB95qR8p-noqmpFAAAAMk2WOMTIvHwLjkYm7D7-fDEDMBS","token_type":"bearer","expires_in":28799}
curl -H "Content-Type: application/json" -H "Authorization: bearer AQAAANCMnd8BFdERjHoAwE_Cl-sBAAAAqHb0qtgH9kellh2kmjYY0gAAAAACAAAAAAADZgAAwAAAABAAAADxCCTIZLbVwdc03NWQwX0lAAAAAASAAACgAAAAEAAAADvwYrMXALrACXLjqG7DC3Z4AAAAisA6L0F2lEM4Jr62FybWbEBALz5rwsd8PHVjgHmeu-Ja1tetuAL6qVSnxVw0Vn-UQcV1HqDJuEZ0_G6ToH9iM3B6Dqvajd6q2LS5kuzgqtmFaX5A47NU_vGNFQY1zuOyMhQ0Z2ZpaTp1T_VuZBvB95qR8p-noqmpFAAAAMk2WOMTIvHwLjkYm7D7-fDEDMBS" http://localhost:6060/api/identity