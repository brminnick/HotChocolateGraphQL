using Android.App;
using Android.Runtime;

namespace HotChocolateGraphQL.Mobile;

#if DEBUG
[Application(NetworkSecurityConfig = "@xml/network_security_config")]
#else
[Application]
#endif
public class MainApplication(IntPtr handle, JniHandleOwnership ownership) : MauiApplication(handle, ownership)
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}