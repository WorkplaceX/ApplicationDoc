# Feature Build Server (CI)
In order to enable build server Continuous integration (CI) on GitHub actions, copy the file **main.yml** (from to)
* Framework/Framework.Cli/Ci/github.com/main.yml
* .github/workflows/main.yml

## Configuration
Now select an environment for example DEV and copy the configuration like this:

```cmd
wpx env name=DEV
wpx config
```
Copy the yellow highlighted json text ConfigCli:
![](/assets/feature-buildserver-config-cli.png)

## GitHub actions
Paste the json text as ConfigCli secret on Github actions like this:
![](/assets/feature-buildserver-config.png)