package mono;

import android.app.Application;
import android.content.Context;
import android.content.IntentFilter;
import android.content.pm.ApplicationInfo;
import android.os.Build;
import java.time.OffsetDateTime;
import java.util.Locale;
import mono.android.BuildConfig;
import mono.android.DebugRuntime;
import mono.android.Runtime;
import mono.android.app.NotifyTimeZoneChanges;
import net.dot.android.ApplicationRegistration;

/* JADX INFO: loaded from: classes3.dex */
public class MonoPackageManager {
    static boolean initialized;
    static Object lock = new Object();

    public static void setContext(Context context) {
    }

    public static void LoadApplication(Context context) {
        String[] strArr;
        synchronized (lock) {
            try {
                ApplicationInfo applicationInfo = context.getApplicationInfo();
                String[] strArr2 = applicationInfo.splitSourceDirs;
                if (strArr2 != null && strArr2.length > 0) {
                    strArr = new String[strArr2.length + 1];
                    strArr[0] = applicationInfo.sourceDir;
                    System.arraycopy(strArr2, 0, strArr, 1, strArr2.length);
                } else {
                    strArr = new String[]{applicationInfo.sourceDir};
                }
                String[] strArr3 = strArr;
                if (context instanceof Application) {
                    ApplicationRegistration.Context = context;
                }
                if (!initialized) {
                    context.registerReceiver(new NotifyTimeZoneChanges(), new IntentFilter("android.intent.action.TIMEZONE_CHANGED"));
                    Locale locale = Locale.getDefault();
                    String str = locale.getLanguage() + "-" + locale.getCountry();
                    String absolutePath = context.getFilesDir().getAbsolutePath();
                    String absolutePath2 = context.getCacheDir().getAbsolutePath();
                    String nativeLibraryPath = getNativeLibraryPath(context);
                    ClassLoader classLoader = context.getClassLoader();
                    String nativeLibraryPath2 = getNativeLibraryPath(applicationInfo);
                    int totalSeconds = OffsetDateTime.now().getOffset().getTotalSeconds();
                    String[] strArr4 = {absolutePath, absolutePath2, nativeLibraryPath};
                    String[] strArr5 = applicationInfo.splitSourceDirs;
                    boolean z = strArr5 != null && strArr5.length > 0;
                    if (BuildConfig.Debug) {
                        System.loadLibrary("xamarin-debug-app-helper");
                        DebugRuntime.init(strArr3, nativeLibraryPath2, strArr4, z);
                    } else {
                        System.loadLibrary("monosgen-2.0");
                    }
                    System.loadLibrary("xamarin-app");
                    if (!BuildConfig.DotNetRuntime) {
                        System.loadLibrary("mono-native");
                    }
                    System.loadLibrary("monodroid");
                    Runtime.initInternal(str, strArr3, nativeLibraryPath2, strArr4, totalSeconds, classLoader, MonoPackageManager_Resources.Assemblies, isEmulator(), z);
                    ApplicationRegistration.registerApplications();
                    initialized = true;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    static boolean isEmulator() {
        String str = Build.HARDWARE;
        return str.contains("ranchu") || str.contains("goldfish");
    }

    static String getNativeLibraryPath(Context context) {
        return getNativeLibraryPath(context.getApplicationInfo());
    }

    static String getNativeLibraryPath(ApplicationInfo applicationInfo) {
        return applicationInfo.nativeLibraryDir;
    }

    public static String[] getAssemblies() {
        return MonoPackageManager_Resources.Assemblies;
    }

    public static String[] getDependencies() {
        return MonoPackageManager_Resources.Dependencies;
    }
}
