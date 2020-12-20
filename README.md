# IOLib_IdentifierLib-Dummy
Unity app to test IO & Identity Library.
 
## In-Game screenshot
Here is the final in-game screenshot displaying the **'Player'** data as **'Level'**, **'Health'** & **'Position'** 
that is **saved** & **loaded** from disk.<br>
Also, a __Unique Identifier__ that is specific to the device that emits the same ID on app launch & re-installs is displayed.

![In-Game screenshot](https://github.com/aalekhm/IOLib_IdentifierLib-Dummy/blob/main/Screenshot.jpeg?raw=true)

Add the project to Unity by selecting the top level folder.<br>
Kindly switch the __Build Settings__ to __'Android'__ via __'File -> Build Settings -> Platform (Android)'__.<br>
Switch to __'PlayerStatsScene'__, if not visible by default.
<br>
<br>
Library wrapper code can be found under:<br>
### __Assets/IO__<br />
__IOWrapper.FastIO__ offers brute force RW(__ReadAllBytes() & WriteAllBytes()__) contents on a specified file along with regular file checking operations like __'Exists()', 'Clear()', 'Rename()' & 'Delete()'__.<br>
Alternatively, it exposes __'OpenForRead()' & 'OpenForWrite()'__ that return __'FileInputStream' & 'FileOutputStream'__ respectively, for more specific low-level file RW operations.<br>
Platform specific calls to the __native library__ is called via an __'...Impl'__ implementor and can be found under the __'Android', 'PC'__  folders.<br>
The __'...Impl'__ implementor acts as a bridge between Unity & Android(Java).<br>
<br>
__Encryption & Decryption__ is embedded inside __IOWrapper.FastIO__ & can be passed in as a parameter to __ReadAllBytes() & WriteAllBytes()__ if required.<br>
Since the idea is not have a brute force cryptology solution, simple X-OR encryption & decryption is adopted for ease of use and understanding on the native side.<br>
<br>
Alternatively, calls to functions written in C++ exposed via a shared lirary(.so) can be found under __Crypto__.<br>
CryptoWrapper is used as a bridge between Unity & Android(C++) to encrypt/decrypt string literals.
<br>
<br>
### __Assets/Identity<br />
__IdentityWrapper.Identity__ class get an __Unique Identifier__ generated natively via the implementor specific to a platform.<br>
On __'Android'__, the device __BRAND, MANUFACTURER, MODEL, ANDROID_ID__ clubbed along with the __Application Package Name__ is used to generate a __Universally Unique Identifier(UUID)__ specific to that particular device.<br>
Subsequent kill relaunch of the application & reinstall generates the same Identifier for that partiucular device.
<br>
<br>
## Library Implementation:<br>
For the specified libraries is under __'ExternalLibrarySource'__.<br>
Each is a __Android Gradle project__ & can be open via Android Studio.
One built, the output library __(.jar or .so)__ is copied automatically to the __Assets/Plugins/Android__ folder.