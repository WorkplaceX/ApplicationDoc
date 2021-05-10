# Continues Integration (CI) and Delivery

In order to update the application WorkplaceX framework provides Continues Integration "out of the box" for

* [GitHub Actions](https://github.com/features/actions)
* [Travis CI](https://travis-ci.org/)
* [Azure Pipelines](https://azure.microsoft.com/en-us/services/devops/pipelines/)

Continues Integration is like a water pipeline through which the whole applications goes after every Git commit. It gets compiled, built, tested, and deployed.
(Image Src="/assets/pipeline.jpg")

The scripts are located in folder **Framework/Framework.Cli/Ci/**

In order to enable for example GitHub Actions typically the (*.yml) file is copied from to;
* Framework/Framework.Cli/Ci/github.com/.main.yml (Template)
* .github/workflows/main.yml