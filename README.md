# IOLib_IdentifierLib
Unity app to test IO & Identity Library.
 
## In-Game screenshot
Here is the final in-game screenshot displaying the **'Player'** data as **'Level'**, **'Health'** & **'Position'** 
that can be **saved** & **loaded** from disk.<br>
Also, a __Unique Identifier__ that is specific to the device and has the same ID on app launch & re-installs is displayed.

![In-Game screenshot](https://github.com/aalekhm/IOLib_IdentifierLib/blob/main/Screenshot.jpeg?raw=true)

### __Steps to build:__<br />
The Unity project is build with __Unity 2019.4.16f1__<br>
Add the project to Unity by selecting the top level folder(referred to it as __root__ in the following description).<br>
Kindly switch the __Build Settings__ to __'Android'__ via __'File -> Build Settings -> Platform (Android)'__.<br>
Switch to or double click the __'PlayerStatsScene'__ under Scenes, if not visible by default.
<br>
<br>
Library wrapper code can be found under:<br>
### IO Library : root/Assets/IO<br />
__IOWrapper.FastIO__ offers brute force RW(__ReadAllBytes() & WriteAllBytes()__) functionality on a specified file along with regular file checking operations like __'Exists()', 'Clear()', 'Rename()' & 'Delete()'__.<br>
Alternatively, it exposes __'OpenForRead()' & 'OpenForWrite()'__ that return __'FileInputStream' & 'FileOutputStream'__ respectively, for more specific low-level file RW operations.<br>
Platform specific calls to the __native library__ is done via an respective __'...Impl'__ implementors that can be found under the __'Android'/'PC'__  folders.<br>
The __'...Impl'__ implementor acts as a bridge between Unity & Android(Java).<br>
<br>
__Encryption & Decryption__ is embedded inside __IOWrapper.FastIO__ & can be turned on/off which is be passed in as a parameter to __WriteAllBytes()__.<br>
If a file is encrypted, the call to __ReadAllBytes()__ will detect it automatically & perform the decryption accordingly. This is done via a specific custom header.<br>
Since the idea is not have a brute force cryptology solution, simple X-OR encryption & decryption is adopted for ease of use and understanding on the native side.<br>
<br>
Alternatively, calls to functions written in C++ exposed via a shared library(.so), can be found under __root/Assets/Crypto__.<br>
__root/Assets/Crypto/CryptoWrapper__ acts as a bridge between Unity & Android(C++) to encrypt/decrypt __string literals__.<br>
This functionality is not used, but the native function calls are tested & are hidden under macro __'TEST_CRYPTOC'__ found in __Player.LoadFromDisk()__.
<br>
<br>
### Identity Library : root/Assets/Identity <br />
__IdentityWrapper.Identity__ class gets an __Unique Identifier__ generated natively via the implementor specific to a platform.<br>
On __'Android'__, the device __BRAND, MANUFACTURER, MODEL, ANDROID_ID__ clubbed along with the __Application Package Name__ is used to generate a __Universally Unique Identifier(UUID)__.<br>
Subsequent kill relaunches of the application & reinstall generate the same Identifier for a particular device.
<br>
<br>
## Library Implementation:<br>
The underlying library implementation can be found under __'root/ExternalLibrarySource'__.<br>
Each is a __Android Gradle project__ & can be open via Android Studio.<br>
All the classes and their functions are self documented as I have tried to use Class/Function names self explanatory wherever possible.<br>
Additionally, the function intention is summarized in a multi-line comment found just above the function definitions.<br>
Once built, the output library __(.jar or .so)__ is copied automatically to the __root/Assets/Plugins/Android__ folder.<br>
