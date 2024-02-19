### C# Test Framework for testing Frontend and Backend functionality

#

#### Framework diagram
![image](https://github.com/coastal-lines/AssessmentDeliveryTestingFramework/blob/main/AssessmentDeliveryTestFramework/Resources/Doc/framework_schema.jpg?raw=true)

#

#### Test types
| HTTP   | Web | Desktop | Mobile  | Visual Tests 
|-----------| ------ |---------|---------|--------------|
| API       | BDD | Windows | Android | Appium       
|  | Selenium |         |         | Sikuli    

#

#### Used dotnet version
- .NET 6.0

#

#### Used applications and services
For some of mocked API tests you have to have an [SoapUI](https://www.soapui.org/) tool.
Also your machine should has [FreeQuizMaker](https://www.mediafreeware.com/free-quiz-maker.html) for some Desktop tests.
Android tests use [Android Emulator](https://developer.android.com/studio).

| API                  | Web           | Desktop             | Mobile
|----------------------|---------------|---------------------| ------ |
| [SoapUI](https://www.soapui.org/) server |  | [FreeQuizMaker](https://www.mediafreeware.com/free-quiz-maker.html) app | [Aptitude app](https://play.google.com/store/apps/details?id=nithra.math.aptitude&hl=en&gl=US&pli=1) app

#

#### .NET SDK installation (cmd)
- Please check your sdk dotnet version 
```sh
dotnet --list-sdks
```
- If you don't have, please use next command for install sdk 6.0
```sh
dotnet install --sdk 6.0
```
- or the latest version
```sh
dotnet install --sdk
```

#

#### Framework installation (cmd)
- Clone this project into your machine
```sh
cd <your_projects_folder>
git clone https://github.com/coastal-lines/AssessmentDeliveryTestingFramework.git
cd AssessmentDeliveryTestingFramework
```
- Restore solution packages
```sh
dotnet restore AssessmentDeliveryTestingFramework.sln
```

#

#### Additional software installation 
- [FreeQuizMaker](https://www.mediafreeware.com/free-quiz-maker.html)
  - If you face with UAC issue, please use watch [my step-by-step video](https://www.youtube.com/watch?v=Jwwn3phG6KA) how to solve this
#
- [Aptitude](https://play.google.com/store/apps/details?id=nithra.math.aptitude&hl=en&gl=US)
  - You should have already installed Android Emulator and any virtual device.
    Instance of AVD should has pre-installed application

#

#### How to run tests (cmd)
- Single test
```sh
cd <AssessmentDeliveryTestFramework_path>\AssessmentDeliveryTests\Web\GorillaTests
dotnet test --filter GorillaTests.Tests.SimpleGorillaTests.SimpleTest
```
