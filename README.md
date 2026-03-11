<img height="100" alt="hyperexecute_logo" src="https://user-images.githubusercontent.com/1688653/159473714-384e60ba-d830-435e-a33f-730df3c3ebc6.png">

HyperExecute is a smart test orchestration platform to run end-to-end Selenium tests (YAML 0.1) and Appium (YAML 0.2) at the fastest speed possible. HyperExecute lets you achieve an accelerated time to market by providing a test infrastructure that offers optimal speed, test orchestration, and detailed execution logs.

The overall experience helps teams test code and fix issues at a much faster pace. HyperExecute is configured using a YAML file. Instead of moving the Hub close to you, HyperExecute brings the test scripts close to the Hub!

* <b>HyperExecute HomePage</b>: https://www.lambdatest.com/hyperexecute
* <b>TestMu AI HomePage</b>: https://www.lambdatest.com
* <b>TestMu AI Support</b>: [support@lambdatest.com](mailto:support@lambdatest.com)

To know more about how HyperExecute does intelligent Test Orchestration, do check out [HyperExecute Getting Started Guide](https://www.lambdatest.com/support/docs/getting-started-with-hyperexecute/)

[<img alt="Try it now" width="200 px" align="center" src="selenium_4/images/Try it Now.svg" />](https://hyperexecute.lambdatest.com/?utm_source=github&utm_medium=repository&utm_content=csharp&utm_term=reqnroll)


## Gitpod

Follow the below steps to run Gitpod button:

1. Click '**Open in Gitpod**' button (You will be redirected to Login/Signup page).
2. Login with TestMu AI credentials and it will be redirected to Gitpod editor in new tab and current tab will show hyperexecute dashboard.

[<img alt="Run in Gitpod" width="200 px" align="center" src="selenium_4/images/Gitpod.svg" />](https://hyperexecute.lambdatest.com/hyperexecute/jobs?type=gitpod&framework=Reqnroll)
---

<!---If logged in, it will be redirected to Gitpod editor in new tab where current tab will show hyperexecute dashboard.

If not logged in, it will be redirected to Login/Signup page and simultaneously redirected to Gitpod editor in a new tab where current tab will show hyperexecute dashboard.

If not signed up, you need to sign up and simultaneously redirected to Gitpod in a new tab where current tab will show hyperexecute dashboard.--->

# How to run Selenium automation tests on HyperExecute (using Reqnroll framework)

* [Pre-requisites](#pre-requisites)
   - [Download HyperExecute CLI](#download-hyperexecute-cli)
   - [Configure Environment Variables](#configure-environment-variables)

* [Matrix Execution with Reqnroll](#matrix-execution-with-reqnroll)
   - [Core](#core)
   - [Pre Steps and Dependency Caching](#pre-steps-and-dependency-caching)
   - [Post Steps](#post-steps)
   - [Artifacts Management](#artifacts-management)
   - [Test Execution](#test-execution)

* [Auto-Split Execution with Reqnroll](#auto-split-execution-with-reqnroll)
   - [Core](#core-1)
   - [Pre Steps and Dependency Caching](#pre-steps-and-dependency-caching-1)
   - [Post Steps](#post-steps-1)
   - [Artifacts Management](#artifacts-management-1)
   - [Test Execution](#test-execution-1)

* [Secrets Management](#secrets-management)
* [Navigation in Automation Dashboard](#navigation-in-automation-dashboard)

# Pre-requisites

Before using HyperExecute, you have to download HyperExecute CLI corresponding to the host OS. Along with it, you also need to export the environment variables *LT_USERNAME* and *LT_ACCESS_KEY* that are available in the [TestMu AI Profile](https://accounts.lambdatest.com/detail/profile) page.

## Download HyperExecute CLI

HyperExecute CLI is the CLI for interacting and running the tests on the HyperExecute Grid. The CLI provides a host of other useful features that accelerate test execution. In order to trigger tests using the CLI, you need to download the HyperExecute CLI binary corresponding to the platform (or OS) from where the tests are triggered:

Also, it is recommended to download the binary in the project's parent directory. Shown below is the location from where you can download the HyperExecute CLI binary:

* Mac: https://downloads.lambdatest.com/hyperexecute/darwin/hyperexecute
* Linux: https://downloads.lambdatest.com/hyperexecute/linux/hyperexecute
* Windows: https://downloads.lambdatest.com/hyperexecute/windows/hyperexecute.exe

## Configure Environment Variables

Before the tests are run, please set the environment variables LT_USERNAME & LT_ACCESS_KEY from the terminal. The account details are available on your [TestMu AI Profile](https://accounts.lambdatest.com/detail/profile) page.

For macOS:

```bash
export LT_USERNAME=LT_USERNAME
export LT_ACCESS_KEY=LT_ACCESS_KEY
```

For Linux:

```bash
export LT_USERNAME=LT_USERNAME
export LT_ACCESS_KEY=LT_ACCESS_KEY
```

For Windows:

```bash
set LT_USERNAME=LT_USERNAME
set LT_ACCESS_KEY=LT_ACCESS_KEY
```

The project structure is as shown below:

```yaml
reqnroll-hyperexecute-sample
      |
      | --- selenium_4
        | --- Features (Contains the feature files)
              |
              | --- playground_search_1.feature
              | --- playground_search_2.feature
              | --- UsersAPI.feature
        |--- Support (Contains the event bindings to perform additional automation logic)
              | --- DriverFactory.cs
              | --- Hooks.cs
        |--- StepDefinitions (Contains the step definitions that correspond to the feature files)
              | --- SearchItemsStepDefinitions.cs
              | --- UsersAPIStepDefinitions.cs
        |--- yaml
              | --- linux
                     | --- reqnroll_hyperexecute_autosplit_sample.yaml
                     | --- reqnroll_hyperexecute_matrix_sample.yaml
              | --- win
                     | --- reqnroll_hyperexecute_autosplit_sample.yaml
                     | --- reqnroll_hyperexecute_matrix_sample.yaml
              | --- mac
                     | --- reqnroll_hyperexecute_autosplit_sample.yaml
                     | --- reqnroll_hyperexecute_matrix_sample.yaml
```

# Matrix Execution with Reqnroll

Matrix-based test execution is used for running the same tests across different test (or input) combinations. The Matrix directive in HyperExecute YAML file is a *key:value* pair where value is an array of strings.

Also, the *key:value* pairs are opaque strings for HyperExecute. For more information about matrix multiplexing, check out the [Matrix Getting Started Guide](https://www.lambdatest.com/support/docs/getting-started-with-hyperexecute/#matrix-based-build-multiplexing)

PS: For demonstration, we have chosen macOS as the preferred choice of platform for executing Reqnroll tests on HyperExecute.

### Core

In the current example, matrix YAML file (*yaml/mac/reqnroll_hyperexecute_matrix_sample.yaml*) in the repo contains the following configuration:

```yaml
globalTimeout: 90
testSuiteTimeout: 90
testSuiteStep: 90
```

Global timeout, testSuite timeout, and testSuite timeout are set to 90 minutes.
 
The target platform is set to macOS. Please set the *[runson]* key to *[win]* or *[linux]* if the tests have to be executed on the Windows or Linux platforms respectively.

```yaml
runson: mac
```

The *matrix* constitutes of the following entries - *project* and *scenario*. This is because parallel execution will be achieved at the *scenario* level.

```yaml
matrix:
  project: ["reqnroll.cloud.sln"]
  scenario: ["searchItems-1", "searchItems-2", "searchItems-3", "api"]
```

The *testSuites* object contains a list of commands (that can be presented in an array). In the current YAML file, commands for executing the tests are put in an array (with a '-' preceding each item). The [*dotnet test*](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test) command is used to run tests located in the current project. In the current project, parallel execution is achieved at the *scenario* level.

Please refer to [Executing Reqnroll tests in parallel](https://docs.reqnroll.net/latest/execution/executing-reqnroll-scenarios.html#) for more information on exeuting Reqnroll scenarios.

```yaml
testSuites:
  - dotnet test $project --filter "(Category=$scenario)"
```

### Pre Steps and Dependency Caching

Dependency caching is enabled in the YAML file to ensure that the package dependencies are not downloaded in subsequent runs. The first step is to set the Key used to cache directories.

```yaml
cacheKey: '{{ checksum "reqnroll.cloud.csproj" }}'
```

Set the array of files & directories to be cached. Separate folders are created for downloading global-packages, http-cache, and plugins-cache. Pleas refer to [Configuring NuGet CLI environment variables](https://docs.microsoft.com/en-us/nuget/reference/cli-reference/cli-ref-environment-variables) to know more about overriding settings in NuGet.Config files.


```yaml
env:
  NUGET_PACKAGES: '/Users/ltuser/.nuget/packages/'
  NUGET_HTTP_CACHE_PATH: '/Users/ltuser/.local/share/NuGet/v3-cache'
  NUGET_PLUGINS_CACHE_PATH: '/Users/ltuser/.local/share/NuGet/plugins-cache'
```

Steps (or commands) that must run before the test execution are listed in the *pre* run step. In the example, the necessary NuGet packages are fetched using the [*dotnet list package*](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-list-package) command. All the local packages are cleared using the *nuget locals all -clear* command, post which the entire project is built from scratch using the *dotnet build -c Release* command.

```yaml
pre:
 # https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-list-package
 - nuget locals all -clear
 - dotnet build -c Release
```

### Post Steps

Steps (or commands) that need to run after the test execution are listed in the *post* step. In the example, we *cat* the contents of *yaml/mac/reqnroll_hyperexecute_matrix_sample.yaml*

```yaml
post:
  - cat yaml/mac/reqnroll_hyperexecute_matrix_sample.yaml
```

### Artifacts Management

The *mergeArtifacts* directive (which is by default *false*) is set to *true* for merging the artifacts and combining artifacts generated under each task.

The *uploadArtefacts* directive informs HyperExecute to upload artifacts [files, reports, etc.] generated after task completion. In the example, *path* consists of a regex for parsing the directories (i.e. *Report/* and *Screenshots/*) that contain the test reports and execution screenshots respectively.

```yaml
mergeArtifacts: true

uploadArtefacts:
 - name: Execution_Report
   path:
    - Report/**
    - Reports/**
 - name: Execution_Screenshots
   path:
    - Screenshots/**/**
    - Reports/**/Screenshots/**
```

HyperExecute also facilitates the provision to download the artifacts on your local machine. To download the artifacts, click on Artifacts button corresponding to the associated TestID.

<img width="1501" height="818" alt="matrix-execution" src="https://github.com/user-attachments/assets/3e32841d-a64a-4365-9c33-bcceebfdf033" />


## Test Execution

The CLI option *--config* is used for providing the custom HyperExecute YAML file (i.e. *yaml/reqnroll_hyperexecute_matrix_sample.yaml*). The *--download-artifacts* option is used to inform HyperExecute to download the artifacts for the job. The *--force-clean-artifacts* option force cleans any existing artifacts for the project.

```bash
./hyperexecute --config yaml/mac/reqnroll_hyperexecute_matrix_sample.yaml --force-clean-artifacts --user $LT_USERNAME --key $LT_ACCESS_KEY
```

Visit [HyperExecute Automation Dashboard](https://automation.lambdatest.com/hyperexecute) to check the status of execution:

<img width="1508" height="939" alt="matrix-dashboard" src="https://github.com/user-attachments/assets/3754c2de-b24c-4722-bfbd-c2a9715aa5a0" />

Shown below is the execution screenshot when the YAML file is triggered from the terminal:

<img width="1512" height="650" alt="matrix-cli-11" src="https://github.com/user-attachments/assets/0e3ada2d-53be-4da9-aa43-71c8ff162049" />

<img width="1498" height="618" alt="matrix-cli-12" src="https://github.com/user-attachments/assets/d2ab6015-8ff3-44a4-8ee6-d4baaaed6eb0" />

## Auto-Split Execution with Reqnroll

Auto-split execution mechanism lets you run tests at predefined concurrency and distribute the tests over the available infrastructure. Concurrency can be achieved at different levels - file, module, test suite, test, scenario, etc.

For more information about auto-split execution, check out the [Auto-Split Getting Started Guide](https://www.lambdatest.com/support/docs/getting-started-with-hyperexecute/#smart-auto-test-splitting)

### Core

Auto-split YAML file (*yaml/mac/reqnroll_hyperexecute_autosplit_sample.yaml*) in the repo contains the following configuration:

```yaml
globalTimeout: 90
testSuiteTimeout: 90
testSuiteStep: 90
```

Global timeout, testSuite timeout, and testSuite timeout are set to 90 minutes.
 
The *runson* key determines the platform (or operating system) on which the tests are executed. Here we have set the target OS as macOS.

```yaml
runson: mac
```

Auto-split is set to true in the YAML file.

```yaml
 autosplit: true
```

*retryOnFailure* is set to true, instructing HyperExecute to retry failed command(s). The retry operation is carried out till the number of retries mentioned in *maxRetries* are exhausted or the command execution results in a *Pass*. In addition, the concurrency (i.e. number of parallel sessions) is set to 4.

```yaml
retryOnFailure: true
maxRetries: 1
concurrency: 4
```

## Pre Steps and Dependency Caching

Dependency caching is enabled in the YAML file to ensure that the package dependencies are not downloaded in subsequent runs. The first step is to set the Key used to cache directories.

```yaml
cacheKey: '{{ checksum "reqnroll.cloud.csproj" }}'
```

Set the array of files & directories to be cached. Separate folders are created for downloading global-packages, http-cache, and plugins-cache. Pleas refer to [Configuring NuGet CLI environment variables](https://docs.microsoft.com/en-us/nuget/reference/cli-reference/cli-ref-environment-variables) to know more about overriding settings in NuGet.Config files.


```yaml
env:
  NUGET_PACKAGES: '/Users/ltuser/.nuget/packages/'
  NUGET_HTTP_CACHE_PATH: '/Users/ltuser/.local/share/NuGet/v3-cache'
  NUGET_PLUGINS_CACHE_PATH: '/Users/ltuser/.local/share/NuGet/plugins-cache'
```

## Post Steps

The *post* directive contains a list of commands that run as a part of post-test execution. Here, the contents of *yaml/mac/reqnroll_hyperexecute_autosplit_sample.yaml* are read using the *cat* command as a part of the post step.

```yaml
post:
  - cat yaml/mac/reqnroll_hyperexecute_autosplit_sample.yaml
```

The *testDiscovery* directive contains the command that gives details of the mode of execution, along with detailing the command that is used for test execution. Here, we are fetching the list of test methods that would be further passed in the *testRunnerCommand*

```yaml
testDiscovery:
  type: raw
  mode: dynamic
  command: grep -rni 'Features' -e '@' --include=\*.feature | sed 's/.*@//'
```

Running the above command on the terminal will give a list of scenarios present in the *feature* files:

* searchItems-1
* searchItems-2
* searchItems-3
* api

The *testRunnerCommand* contains the command that is used for triggering the test. The output fetched from the *testDiscoverer* command acts as an input to the *testRunner* command.

```yaml
testRunnerCommand: dotnet test --logger "console;verbosity=detailed" --filter "(Category=$test)"
```

### Artifacts Management

The *mergeArtifacts* directive (which is by default *false*) is set to *true* for merging the artifacts and combining artifacts generated under each task.

The *uploadArtefacts* directive informs HyperExecute to upload artifacts [files, reports, etc.] generated after task completion. In the example, *path* consists of a regex for parsing the directories (i.e. *Report/* and *Screenshots/*) that contain the test reports and execution screenshots respectively.

```yaml
mergeArtifacts: true

uploadArtefacts:
 - name: Execution_Report
   path:
    - Report/**
    - Reports/**
 - name: Execution_Screenshots
   path:
    - Screenshots/**/**
    - Reports/**/Screenshots/**
```

HyperExecute also facilitates the provision to download the artifacts on your local machine. To download the artifacts, click on Artifacts button corresponding to the associated TestID.

<img width="1512" height="949" alt="autosplit-dashboard-1" src="https://github.com/user-attachments/assets/2b84ecb8-7e16-4f89-8604-ffc5b24392f1" />


### Test Execution

The CLI option *--config* is used for providing the custom HyperExecute YAML file (i.e. *yaml/mac/reqnroll_hyperexecute_autosplit_sample.yaml*). Run the following command on the terminal to trigger the tests in C# files on the HyperExecute grid. The *--download-artifacts* option is used to inform HyperExecute to download the artifacts for the job. The *--force-clean-artifacts* option force cleans any existing artifacts for the project.

```bash
./hyperexecute --config yaml/mac/reqnroll_hyperexecute_autosplit_sample.yaml --force-clean-artifacts --user $LT_USERNAME --key $LT_ACCESS_KEY
```

Visit [HyperExecute Automation Dashboard](https://automation.lambdatest.com/hyperexecute) to check the status of execution

<img width="1512" height="949" alt="autosplit-dashboard-2" src="https://github.com/user-attachments/assets/3d1f0d30-252f-4e98-aca9-d522f801291f" />

Shown below is the execution screenshot when the YAML file is triggered from the terminal:

<img width="1488" height="594" alt="autosplit-cli-1" src="https://github.com/user-attachments/assets/f5070b36-157f-41dc-94f0-480a3d17dc2c" />

<img width="1488" height="594" alt="autosplit-cli-2" src="https://github.com/user-attachments/assets/5079b764-78a2-4e05-94f6-11494425ddd1" />

## Secrets Management

In case you want to use any secret keys in the YAML file, the same can be set by clicking on the *Secrets* button the dashboard.

<img width="1512" height="440" alt="secrets-1" src="https://github.com/user-attachments/assets/f7b24fe5-feda-43a0-8b4b-e750428a077d" />

Now create a *secret* key that you can use in the HyperExecute YAML file.

<img width="1512" height="632" alt="secrets-2" src="https://github.com/user-attachments/assets/592e1c4e-876f-41c1-9fd6-539575e045ca" />

All you need to do is create an environment variable that uses the secret key:

```yaml
env:
  PAT: ${{ .secrets.testKey }}
```

## Navigation in Automation Dashboard

HyperExecute lets you navigate from/to *Test Logs* in Automation Dashboard from/to *HyperExecute Logs*. You also get relevant get relevant Selenium test details like video, network log, commands, Exceptions & more in the Dashboard. Effortlessly navigate from the automation dashboard to HyperExecute logs (and vice-versa) to get more details of the test execution.

Shown below is the HyperExecute Automation dashboard which also lists the tests that were executed as a part of the test suite:

<img width="1512" height="952" alt="hyperexecute-tests" src="https://github.com/user-attachments/assets/fdc56abe-a2dd-4dc1-aaa0-96b838886680" />

Here is a screenshot that lists the automation test that was executed on the HyperExecute grid:

<img width="1512" height="952" alt="automation-tests" src="https://github.com/user-attachments/assets/334c4315-2c51-4f74-929c-23048be4abe6" />


## TestMu AI Community :busts_in_silhouette:

The [TestMu AI Community](https://community.lambdatest.com/) allows people to interact with tech enthusiasts. Connect, ask questions, and learn from tech-savvy people. Discuss best practises in web development, testing, and DevOps with professionals from across the globe.

## Documentation & Resources :books:
      
If you want to learn more about the TestMu AI's features, setup, and usage, visit the [TestMu AI documentation](https://www.lambdatest.com/support/docs/). You can also find in-depth tutorials around test automation, mobile app testing, responsive testing, manual testing on [TestMu AI Blog](https://www.lambdatest.com/blog/) and [TestMu AI Learning Hub](https://www.lambdatest.com/learning-hub/).     
      
## What's New At TestMu AI ❓

To stay updated with the latest features and product add-ons, visit [Changelog](https://changelog.testmu.ai/) 
      
## About TestMu AI

[TestMu AI](https://www.testmu.ai/?utm_source=github&utm_medium=repo&utm_campaign=appium-flutter-java-sample) (Formerly LambdaTest) is a Full Stack Agentic AI Quality Engineering platform that empowers teams to test intelligently and ship faster. Engineered for scale, it offers end-to-end AI agents to plan, author, execute, and analyze software quality. AI-native by design, the platform enables testing of web, mobile, and enterprise applications at any scale across real devices, real browsers, and custom real-world environments.    

### Features

* Run Selenium, Cypress, Puppeteer, Playwright, and Appium automation tests across 3000+ real desktop and mobile environments.
* Real-time cross browser testing on 3000+ environments.
* Test on Real device cloud
* Blazing fast test automation with HyperExecute
* Accelerate testing, shorten job times and get faster feedback on code changes with Test At Scale.
* Smart Visual Regression Testing on cloud
* 120+ third-party integrations with your favorite tool for CI/CD, Project Management, Codeless Automation, and more.
* Automated Screenshot testing across multiple browsers in a single click.
* Local testing of web and mobile apps.
* Online Accessibility Testing across 3000+ desktop and mobile browsers, browser versions, and operating systems.
* Geolocation testing of web and mobile apps across 53+ countries.
    
[<img height="58" width="200" src="https://user-images.githubusercontent.com/70570645/171866795-52c11b49-0728-4229-b073-4b704209ddde.png">](https://accounts.lambdatest.com/register)
      
## We are here to help you :headphones:

* Got a query? we are available 24x7 to help. [Contact Us](mailto:support@lambdatest.com)
* For more info, visit - https://www.testmuai.com