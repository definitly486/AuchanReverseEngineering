package com.google.android.gms.dynamite;

import android.content.ContentProviderClient;
import android.content.Context;
import android.content.pm.ApplicationInfo;
import android.content.pm.ProviderInfo;
import android.database.Cursor;
import android.database.MatrixCursor;
import android.net.Uri;
import android.os.Build;
import android.os.IBinder;
import android.os.IInterface;
import android.os.RemoteException;
import android.os.SystemClock;
import android.util.Log;
import com.google.android.gms.common.GoogleApiAvailabilityLight;
import com.google.android.gms.common.annotation.KeepForSdk;
import com.google.android.gms.common.internal.Objects;
import com.google.android.gms.common.internal.Preconditions;
import com.google.android.gms.common.util.CrashUtils;
import com.google.android.gms.common.util.DynamiteApi;
import com.google.android.gms.common.util.PlatformVersion;
import com.google.android.gms.dynamic.IObjectWrapper;
import com.google.android.gms.dynamic.ObjectWrapper;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;
import org.tensorflow.lite.schema.BuiltinOperator;

/* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
/* JADX INFO: loaded from: classes.dex */
@KeepForSdk
public final class DynamiteModule {

    @KeepForSdk
    public static final int LOCAL = -1;

    @KeepForSdk
    public static final int NONE = 0;

    @KeepForSdk
    public static final int NO_SELECTION = 0;

    @KeepForSdk
    public static final int REMOTE = 1;
    private static Boolean zzb = null;
    private static String zzc = null;
    private static boolean zzd = false;
    private static int zze = -1;
    private static Boolean zzf;
    private static zzo zzk;
    private static zzp zzl;
    private final Context zzj;
    private static final ThreadLocal zzg = new ThreadLocal();
    private static final ThreadLocal zzh = new zzd();
    private static final VersionPolicy.IVersions zzi = new zze();

    @KeepForSdk
    public static final VersionPolicy PREFER_REMOTE = new zzf();

    @KeepForSdk
    public static final VersionPolicy PREFER_LOCAL = new zzg();

    @KeepForSdk
    public static final VersionPolicy PREFER_REMOTE_VERSION_NO_FORCE_STAGING = new zzh();

    @KeepForSdk
    public static final VersionPolicy PREFER_HIGHEST_OR_LOCAL_VERSION = new zzi();

    @KeepForSdk
    public static final VersionPolicy PREFER_HIGHEST_OR_LOCAL_VERSION_NO_FORCE_STAGING = new zzj();

    @KeepForSdk
    public static final VersionPolicy PREFER_HIGHEST_OR_REMOTE_VERSION = new zzk();
    public static final VersionPolicy zza = new zzl();

    /* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
    @DynamiteApi
    public static class DynamiteLoaderClassLoader {
        public static ClassLoader sClassLoader;
    }

    /* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
    @KeepForSdk
    public static class LoadingException extends Exception {
        /* synthetic */ LoadingException(String str, Throwable th, byte[] bArr) {
            super(str, th);
        }

        /* synthetic */ LoadingException(String str, byte[] bArr) {
            super(str);
        }
    }

    /* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
    public interface VersionPolicy {

        /* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
        @KeepForSdk
        public interface IVersions {
            int zza(Context context, String str, boolean z);

            int zzb(Context context, String str);
        }

        /* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
        @KeepForSdk
        public static class SelectionResult {

            @KeepForSdk
            public int localVersion = 0;

            @KeepForSdk
            public int remoteVersion = 0;

            @KeepForSdk
            public int selection = 0;
        }

        @KeepForSdk
        SelectionResult selectModule(Context context, String str, IVersions iVersions);
    }

    private DynamiteModule(Context context) {
        Preconditions.checkNotNull(context);
        this.zzj = context;
    }

    @KeepForSdk
    public static int getLocalVersion(Context context, String str) {
        try {
            ClassLoader classLoader = context.getApplicationContext().getClassLoader();
            StringBuilder sb = new StringBuilder(String.valueOf(str).length() + 61);
            sb.append("com.google.android.gms.dynamite.descriptors.");
            sb.append(str);
            sb.append(".ModuleDescriptor");
            Class<?> clsLoadClass = classLoader.loadClass(sb.toString());
            Field declaredField = clsLoadClass.getDeclaredField("MODULE_ID");
            Field declaredField2 = clsLoadClass.getDeclaredField("MODULE_VERSION");
            if (Objects.equal(declaredField.get(null), str)) {
                return declaredField2.getInt(null);
            }
            String strValueOf = String.valueOf(declaredField.get(null));
            StringBuilder sb2 = new StringBuilder(strValueOf.length() + 50 + String.valueOf(str).length() + 1);
            sb2.append("Module descriptor id '");
            sb2.append(strValueOf);
            sb2.append("' didn't match expected id '");
            sb2.append(str);
            sb2.append("'");
            Log.e("DynamiteModule", sb2.toString());
            return 0;
        } catch (ClassNotFoundException unused) {
            StringBuilder sb3 = new StringBuilder(String.valueOf(str).length() + 45);
            sb3.append("Local module descriptor class for ");
            sb3.append(str);
            sb3.append(" not found.");
            Log.w("DynamiteModule", sb3.toString());
            return 0;
        } catch (Exception e) {
            Log.e("DynamiteModule", "Failed to load module descriptor class: ".concat(String.valueOf(e.getMessage())));
            return 0;
        }
    }

    @KeepForSdk
    public static int getRemoteVersion(Context context, String str) {
        return zza(context, str, false);
    }

    /* JADX WARN: Code duplicated, block: B:101:0x0267 A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:105:0x0272 A[Catch: all -> 0x0270, TRY_ENTER, TryCatch #0 {, blocks: (B:35:0x00f1, B:37:0x00f7, B:38:0x00f9, B:105:0x0272, B:106:0x027a), top: B:149:0x00f1 }] */
    /* JADX WARN: Code duplicated, block: B:125:0x02d7  */
    /* JADX WARN: Code duplicated, block: B:126:0x02dd  */
    /* JADX WARN: Code duplicated, block: B:129:0x02e6  */
    /* JADX WARN: Code duplicated, block: B:134:0x02f8 A[Catch: all -> 0x00c3, TryCatch #1 {all -> 0x00c3, blocks: (B:5:0x0045, B:9:0x00bc, B:16:0x00c8, B:19:0x00ce, B:32:0x00ec, B:109:0x027d, B:110:0x0288, B:118:0x0298, B:120:0x02c0, B:122:0x02cf, B:132:0x02ef, B:133:0x02f7, B:113:0x028b, B:114:0x028c, B:115:0x0294, B:134:0x02f8, B:135:0x0319, B:136:0x031a, B:137:0x036c), top: B:150:0x0045 }] */
    /* JADX WARN: Code duplicated, block: B:149:0x00f1 A[EXC_TOP_SPLITTER, SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:151:0x0137 A[EXC_TOP_SPLITTER, SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:19:0x00ce A[Catch: all -> 0x00c3, TRY_LEAVE, TryCatch #1 {all -> 0x00c3, blocks: (B:5:0x0045, B:9:0x00bc, B:16:0x00c8, B:19:0x00ce, B:32:0x00ec, B:109:0x027d, B:110:0x0288, B:118:0x0298, B:120:0x02c0, B:122:0x02cf, B:132:0x02ef, B:133:0x02f7, B:113:0x028b, B:114:0x028c, B:115:0x0294, B:134:0x02f8, B:135:0x0319, B:136:0x031a, B:137:0x036c), top: B:150:0x0045 }] */
    /* JADX WARN: Code duplicated, block: B:22:0x00d6  */
    /* JADX WARN: Code duplicated, block: B:23:0x00da  */
    /* JADX WARN: Code duplicated, block: B:26:0x00e1  */
    /* JADX WARN: Code duplicated, block: B:29:0x00e8  */
    /* JADX WARN: Code duplicated, block: B:31:0x00eb  */
    /* JADX WARN: Code duplicated, block: B:37:0x00f7 A[Catch: all -> 0x0270, TryCatch #0 {, blocks: (B:35:0x00f1, B:37:0x00f7, B:38:0x00f9, B:105:0x0272, B:106:0x027a), top: B:149:0x00f1 }] */
    /* JADX WARN: Code duplicated, block: B:40:0x00fc A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TRY_ENTER, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:42:0x0103 A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:47:0x013c A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TRY_ENTER, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:77:0x01bb A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:82:0x01c7 A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:84:0x01fe A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:86:0x0205 A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:88:0x020d A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:89:0x021c A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:91:0x0225 A[DONT_INVERT] */
    /* JADX WARN: Code duplicated, block: B:92:0x0227 A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:93:0x0237 A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:96:0x024c A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:97:0x0255 A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Code duplicated, block: B:99:0x025e A[Catch: all -> 0x0174, LoadingException -> 0x0179, RemoteException -> 0x017e, TryCatch #8 {RemoteException -> 0x017e, LoadingException -> 0x0179, all -> 0x0174, blocks: (B:34:0x00f0, B:40:0x00fc, B:42:0x0103, B:43:0x0136, B:47:0x013c, B:49:0x0144, B:51:0x0148, B:52:0x0153, B:59:0x0160, B:67:0x0196, B:69:0x019e, B:70:0x01a5, B:71:0x01ae, B:66:0x0183, B:74:0x01b1, B:75:0x01b2, B:76:0x01ba, B:77:0x01bb, B:78:0x01c3, B:81:0x01c6, B:82:0x01c7, B:84:0x01fe, B:86:0x0205, B:88:0x020d, B:94:0x0246, B:96:0x024c, B:97:0x0255, B:98:0x025d, B:89:0x021c, B:90:0x0224, B:92:0x0227, B:93:0x0237, B:99:0x025e, B:100:0x0266, B:101:0x0267, B:102:0x026f, B:108:0x027c), top: B:157:0x00f0 }] */
    /* JADX WARN: Multi-variable type inference failed */
    /* JADX WARN: Type inference failed for: r31v0, types: [com.google.android.gms.dynamite.DynamiteModule$VersionPolicy] */
    /* JADX WARN: Type inference failed for: r4v11 */
    /* JADX WARN: Type inference failed for: r4v36 */
    /* JADX WARN: Type inference failed for: r4v9, types: [android.content.Context] */
    @KeepForSdk
    public static DynamiteModule load(Context context, VersionPolicy versionPolicy, String str) throws LoadingException {
        ?? r4;
        int i;
        DynamiteModule dynamiteModuleZze;
        Cursor cursor;
        int i2;
        Boolean bool;
        zzo zzoVarZzg;
        int iZzi;
        IObjectWrapper iObjectWrapperZze;
        Object objUnwrap;
        zzm zzmVar;
        zzp zzpVar;
        zzm zzmVar2;
        boolean z;
        IObjectWrapper iObjectWrapperZze2;
        Cursor cursor2;
        String str2 = StringUtils.PROCESS_POSTFIX_DELIMITER;
        Context applicationContext = context.getApplicationContext();
        byte[] bArr = null;
        if (applicationContext == null) {
            throw new LoadingException("null application Context", null);
        }
        ThreadLocal threadLocal = zzg;
        zzm zzmVar3 = (zzm) threadLocal.get();
        zzm zzmVar4 = new zzm(null);
        threadLocal.set(zzmVar4);
        ThreadLocal threadLocal2 = zzh;
        Long l = (Long) threadLocal2.get();
        long jLongValue = l.longValue();
        try {
            threadLocal2.set(Long.valueOf(SystemClock.uptimeMillis()));
            VersionPolicy.SelectionResult selectionResultSelectModule = versionPolicy.selectModule(context, str, zzi);
            int i3 = selectionResultSelectModule.localVersion;
            int i4 = selectionResultSelectModule.remoteVersion;
            StringBuilder sb = new StringBuilder(String.valueOf(str).length() + 26 + String.valueOf(i3).length() + 19 + String.valueOf(str).length() + 1 + String.valueOf(i4).length());
            sb.append("Considering local module ");
            sb.append(str);
            sb.append(StringUtils.PROCESS_POSTFIX_DELIMITER);
            sb.append(i3);
            sb.append(" and remote module ");
            sb.append(str);
            sb.append(StringUtils.PROCESS_POSTFIX_DELIMITER);
            sb.append(i4);
            Log.i("DynamiteModule", sb.toString());
            int i5 = selectionResultSelectModule.selection;
            if (i5 != 0) {
                if (i5 != -1) {
                    if (i5 == 1 || selectionResultSelectModule.remoteVersion != 0) {
                        if (i5 == -1) {
                            DynamiteModule dynamiteModuleZze2 = zze(applicationContext, str);
                            if (jLongValue == 0) {
                                threadLocal2.remove();
                            } else {
                                threadLocal2.set(l);
                            }
                            cursor2 = zzmVar4.zza;
                            if (cursor2 != null) {
                                cursor2.close();
                            }
                            threadLocal.set(zzmVar3);
                            return dynamiteModuleZze2;
                        }
                        if (i5 == 1) {
                            StringBuilder sb2 = new StringBuilder(String.valueOf(i5).length() + 36);
                            sb2.append("VersionPolicy returned invalid code:");
                            sb2.append(i5);
                            throw new LoadingException(sb2.toString(), null);
                        }
                        try {
                            try {
                                i2 = selectionResultSelectModule.remoteVersion;
                                try {
                                    synchronized (DynamiteModule.class) {
                                        if (zzb(context)) {
                                            throw new LoadingException("Remote loading disabled", null);
                                        }
                                        bool = zzb;
                                    }
                                    if (bool != null) {
                                        throw new LoadingException("Failed to determine which loading route to use.", null);
                                    }
                                    if (bool.booleanValue()) {
                                        StringBuilder sb3 = new StringBuilder(String.valueOf(str).length() + 40 + String.valueOf(i2).length());
                                        sb3.append("Selected remote version of ");
                                        sb3.append(str);
                                        sb3.append(", version >= ");
                                        sb3.append(i2);
                                        Log.i("DynamiteModule", sb3.toString());
                                        synchronized (DynamiteModule.class) {
                                            zzpVar = zzl;
                                        }
                                        if (zzpVar != null) {
                                            throw new LoadingException("DynamiteLoaderV2 was not cached.", null);
                                        }
                                        zzmVar2 = (zzm) threadLocal.get();
                                        if (zzmVar2 != null || zzmVar2.zza == null) {
                                            throw new LoadingException("No result cursor", null);
                                        }
                                        Context applicationContext2 = context.getApplicationContext();
                                        Cursor cursor3 = zzmVar2.zza;
                                        ObjectWrapper.wrap(null);
                                        synchronized (DynamiteModule.class) {
                                            z = zze >= 2;
                                        }
                                        if (z) {
                                            Log.v("DynamiteModule", "Dynamite loader version >= 2, using loadModule2NoCrashUtils");
                                            iObjectWrapperZze2 = zzpVar.zzf(ObjectWrapper.wrap(applicationContext2), str, i2, ObjectWrapper.wrap(cursor3));
                                        } else {
                                            Log.w("DynamiteModule", "Dynamite loader version < 2, falling back to loadModule2");
                                            iObjectWrapperZze2 = zzpVar.zze(ObjectWrapper.wrap(applicationContext2), str, i2, ObjectWrapper.wrap(cursor3));
                                        }
                                        Context context2 = (Context) ObjectWrapper.unwrap(iObjectWrapperZze2);
                                        if (context2 == null) {
                                            throw new LoadingException("Failed to get module context", bArr);
                                        }
                                        dynamiteModuleZze = new DynamiteModule(context2);
                                    } else {
                                        StringBuilder sb4 = new StringBuilder(String.valueOf(str).length() + 40 + String.valueOf(i2).length());
                                        sb4.append("Selected remote version of ");
                                        sb4.append(str);
                                        sb4.append(", version >= ");
                                        sb4.append(i2);
                                        Log.i("DynamiteModule", sb4.toString());
                                        zzoVarZzg = zzg(context);
                                        if (zzoVarZzg != null) {
                                            throw new LoadingException("Failed to create IDynamiteLoader.", null);
                                        }
                                        iZzi = zzoVarZzg.zzi();
                                        if (iZzi >= 3) {
                                            zzmVar = (zzm) threadLocal.get();
                                            if (zzmVar != null) {
                                                throw new LoadingException("No cached result cursor holder", null);
                                            }
                                            iObjectWrapperZze = zzoVarZzg.zzk(ObjectWrapper.wrap(context), str, i2, ObjectWrapper.wrap(zzmVar.zza));
                                        } else if (iZzi == 2) {
                                            Log.w("DynamiteModule", "IDynamite loader version = 2");
                                            iObjectWrapperZze = zzoVarZzg.zzg(ObjectWrapper.wrap(context), str, i2);
                                        } else {
                                            Log.w("DynamiteModule", "Dynamite loader version < 2, falling back to createModuleContext");
                                            iObjectWrapperZze = zzoVarZzg.zze(ObjectWrapper.wrap(context), str, i2);
                                        }
                                        objUnwrap = ObjectWrapper.unwrap(iObjectWrapperZze);
                                        if (objUnwrap != null) {
                                            throw new LoadingException("Failed to load remote module.", null);
                                        }
                                        dynamiteModuleZze = new DynamiteModule((Context) objUnwrap);
                                    }
                                    if (jLongValue == 0) {
                                        zzh.remove();
                                    } else {
                                        zzh.set(l);
                                    }
                                    cursor = zzmVar4.zza;
                                    if (cursor != null) {
                                        cursor.close();
                                    }
                                    zzg.set(zzmVar3);
                                    return dynamiteModuleZze;
                                } catch (RemoteException e) {
                                    throw new LoadingException("Failed to load remote module.", e, null);
                                } catch (LoadingException e2) {
                                    throw e2;
                                } catch (Throwable th) {
                                    CrashUtils.addDynamiteErrorToDropBox(context, th);
                                    throw new LoadingException("Failed to load remote module.", th, null);
                                }
                            } catch (LoadingException e3) {
                                e = e3;
                                r4 = context;
                                String message = e.getMessage();
                                StringBuilder sb5 = new StringBuilder(String.valueOf(message).length() + 30);
                                sb5.append("Failed to load remote module: ");
                                sb5.append(message);
                                Log.w("DynamiteModule", sb5.toString());
                                i = selectionResultSelectModule.localVersion;
                                if (i != 0 || versionPolicy.selectModule(r4, str, new zzn(i, 0)).selection != -1) {
                                    throw new LoadingException("Remote load failed. No local fallback found.", e, null);
                                }
                                dynamiteModuleZze = zze(applicationContext, str);
                            }
                        } catch (LoadingException e4) {
                            e = e4;
                            r4 = str2;
                            String message2 = e.getMessage();
                            StringBuilder sb6 = new StringBuilder(String.valueOf(message2).length() + 30);
                            sb6.append("Failed to load remote module: ");
                            sb6.append(message2);
                            Log.w("DynamiteModule", sb6.toString());
                            i = selectionResultSelectModule.localVersion;
                            if (i != 0) {
                            }
                            throw new LoadingException("Remote load failed. No local fallback found.", e, null);
                        }
                    }
                } else if (selectionResultSelectModule.localVersion != 0) {
                    i5 = -1;
                    if (i5 == 1) {
                    }
                    if (i5 == -1) {
                        DynamiteModule dynamiteModuleZze3 = zze(applicationContext, str);
                        if (jLongValue == 0) {
                            threadLocal2.remove();
                        } else {
                            threadLocal2.set(l);
                        }
                        cursor2 = zzmVar4.zza;
                        if (cursor2 != null) {
                            cursor2.close();
                        }
                        threadLocal.set(zzmVar3);
                        return dynamiteModuleZze3;
                    }
                    if (i5 == 1) {
                        StringBuilder sb7 = new StringBuilder(String.valueOf(i5).length() + 36);
                        sb7.append("VersionPolicy returned invalid code:");
                        sb7.append(i5);
                        throw new LoadingException(sb7.toString(), null);
                    }
                    i2 = selectionResultSelectModule.remoteVersion;
                    synchronized (DynamiteModule.class) {
                        if (zzb(context)) {
                            throw new LoadingException("Remote loading disabled", null);
                        }
                        bool = zzb;
                        if (bool != null) {
                            throw new LoadingException("Failed to determine which loading route to use.", null);
                        }
                        if (bool.booleanValue()) {
                            StringBuilder sb8 = new StringBuilder(String.valueOf(str).length() + 40 + String.valueOf(i2).length());
                            sb8.append("Selected remote version of ");
                            sb8.append(str);
                            sb8.append(", version >= ");
                            sb8.append(i2);
                            Log.i("DynamiteModule", sb8.toString());
                            synchronized (DynamiteModule.class) {
                                zzpVar = zzl;
                                if (zzpVar != null) {
                                    throw new LoadingException("DynamiteLoaderV2 was not cached.", null);
                                }
                                zzmVar2 = (zzm) threadLocal.get();
                                if (zzmVar2 != null) {
                                }
                                throw new LoadingException("No result cursor", null);
                            }
                        }
                        StringBuilder sb9 = new StringBuilder(String.valueOf(str).length() + 40 + String.valueOf(i2).length());
                        sb9.append("Selected remote version of ");
                        sb9.append(str);
                        sb9.append(", version >= ");
                        sb9.append(i2);
                        Log.i("DynamiteModule", sb9.toString());
                        zzoVarZzg = zzg(context);
                        if (zzoVarZzg != null) {
                            throw new LoadingException("Failed to create IDynamiteLoader.", null);
                        }
                        iZzi = zzoVarZzg.zzi();
                        if (iZzi >= 3) {
                            zzmVar = (zzm) threadLocal.get();
                            if (zzmVar != null) {
                                throw new LoadingException("No cached result cursor holder", null);
                            }
                            iObjectWrapperZze = zzoVarZzg.zzk(ObjectWrapper.wrap(context), str, i2, ObjectWrapper.wrap(zzmVar.zza));
                        } else if (iZzi == 2) {
                            Log.w("DynamiteModule", "IDynamite loader version = 2");
                            iObjectWrapperZze = zzoVarZzg.zzg(ObjectWrapper.wrap(context), str, i2);
                        } else {
                            Log.w("DynamiteModule", "Dynamite loader version < 2, falling back to createModuleContext");
                            iObjectWrapperZze = zzoVarZzg.zze(ObjectWrapper.wrap(context), str, i2);
                        }
                        objUnwrap = ObjectWrapper.unwrap(iObjectWrapperZze);
                        if (objUnwrap != null) {
                            throw new LoadingException("Failed to load remote module.", null);
                        }
                        dynamiteModuleZze = new DynamiteModule((Context) objUnwrap);
                        if (jLongValue == 0) {
                            zzh.remove();
                        } else {
                            zzh.set(l);
                        }
                        cursor = zzmVar4.zza;
                        if (cursor != null) {
                            cursor.close();
                        }
                        zzg.set(zzmVar3);
                        return dynamiteModuleZze;
                    }
                }
            }
            int i6 = selectionResultSelectModule.localVersion;
            int i7 = selectionResultSelectModule.remoteVersion;
            StringBuilder sb10 = new StringBuilder(String.valueOf(str).length() + 46 + String.valueOf(i6).length() + 23 + String.valueOf(i7).length() + 1);
            sb10.append("No acceptable module ");
            sb10.append(str);
            sb10.append(" found. Local version is ");
            sb10.append(i6);
            sb10.append(" and remote version is ");
            sb10.append(i7);
            sb10.append(".");
            throw new LoadingException(sb10.toString(), null);
        } catch (Throwable th2) {
            if (jLongValue == 0) {
                zzh.remove();
            } else {
                zzh.set(l);
            }
            Cursor cursor4 = zzmVar4.zza;
            if (cursor4 != null) {
                cursor4.close();
            }
            zzg.set(zzmVar3);
            throw th2;
        }
    }

    /* JADX WARN: Code duplicated, block: B:107:0x018f A[Catch: all -> 0x00f4, TRY_ENTER, TRY_LEAVE, TryCatch #8 {all -> 0x00f4, blocks: (B:4:0x0006, B:65:0x00e9, B:67:0x00ef, B:75:0x011d, B:103:0x0181, B:107:0x018f, B:125:0x01ec, B:126:0x01ef, B:120:0x01e3, B:73:0x00fa, B:128:0x01f1, B:5:0x0007, B:8:0x000d, B:9:0x0029, B:63:0x00e6, B:22:0x004d, B:46:0x00a5, B:49:0x00a8, B:56:0x00c0, B:64:0x00e8, B:62:0x00c6), top: B:141:0x0006, inners: #6, #7 }] */
    /* JADX WARN: Code duplicated, block: B:52:0x00b4 A[Catch: all -> 0x003a, TryCatch #11 {all -> 0x003a, blocks: (B:10:0x002a, B:12:0x0036, B:53:0x00bd, B:17:0x003f, B:19:0x0046, B:21:0x004c, B:26:0x0053, B:28:0x0057, B:32:0x0061, B:34:0x0069, B:37:0x0070, B:44:0x009c, B:45:0x00a4, B:40:0x0077, B:42:0x007d, B:43:0x008e, B:48:0x00a7, B:51:0x00aa, B:52:0x00b4, B:18:0x0042), top: B:142:0x002a, inners: #12 }] */
    public static int zza(Context context, String str, boolean z) {
        Throwable th;
        RemoteException remoteException;
        Cursor cursor;
        try {
            synchronized (DynamiteModule.class) {
                Boolean bool = zzb;
                Cursor cursor2 = null;
                int iZzf = 0;
                if (bool == null) {
                    try {
                        Field declaredField = context.getApplicationContext().getClassLoader().loadClass(DynamiteLoaderClassLoader.class.getName()).getDeclaredField("sClassLoader");
                        synchronized (declaredField.getDeclaringClass()) {
                            try {
                                ClassLoader classLoader = (ClassLoader) declaredField.get(null);
                                if (classLoader == ClassLoader.getSystemClassLoader()) {
                                    bool = Boolean.FALSE;
                                } else if (classLoader != null) {
                                    try {
                                        zzf(classLoader);
                                    } catch (LoadingException unused) {
                                    }
                                    bool = Boolean.TRUE;
                                } else {
                                    if (!zzb(context)) {
                                        return 0;
                                    }
                                    if (zzd) {
                                        declaredField.set(null, ClassLoader.getSystemClassLoader());
                                        bool = Boolean.FALSE;
                                    } else {
                                        Boolean bool2 = Boolean.TRUE;
                                        if (bool2.equals(null)) {
                                            declaredField.set(null, ClassLoader.getSystemClassLoader());
                                            bool = Boolean.FALSE;
                                        } else {
                                            try {
                                                int iZzc = zzc(context, str, z, true);
                                                String str2 = zzc;
                                                if (str2 != null && !str2.isEmpty()) {
                                                    ClassLoader classLoaderZza = zzb.zza();
                                                    if (classLoaderZza == null) {
                                                        if (Build.VERSION.SDK_INT >= 29) {
                                                            DynamiteModule$$ExternalSyntheticApiModelOutline1.m();
                                                            String str3 = zzc;
                                                            Preconditions.checkNotNull(str3);
                                                            classLoaderZza = DynamiteModule$$ExternalSyntheticApiModelOutline0.m(str3, ClassLoader.getSystemClassLoader());
                                                        } else {
                                                            String str4 = zzc;
                                                            Preconditions.checkNotNull(str4);
                                                            classLoaderZza = new zzc(str4, ClassLoader.getSystemClassLoader());
                                                        }
                                                    }
                                                    zzf(classLoaderZza);
                                                    declaredField.set(null, classLoaderZza);
                                                    zzb = bool2;
                                                    return iZzc;
                                                }
                                                return iZzc;
                                            } catch (LoadingException unused2) {
                                                declaredField.set(null, ClassLoader.getSystemClassLoader());
                                                bool = Boolean.FALSE;
                                            }
                                        }
                                    }
                                }
                                zzb = bool;
                            } catch (Throwable th2) {
                                throw th2;
                            }
                        }
                    } catch (ClassNotFoundException | IllegalAccessException | NoSuchFieldException e) {
                        String string = e.toString();
                        StringBuilder sb = new StringBuilder(string.length() + 30);
                        sb.append("Failed to load module via V2: ");
                        sb.append(string);
                        Log.w("DynamiteModule", sb.toString());
                        bool = Boolean.FALSE;
                    }
                }
                if (bool.booleanValue()) {
                    try {
                        return zzc(context, str, z, false);
                    } catch (LoadingException e2) {
                        String message = e2.getMessage();
                        StringBuilder sb2 = new StringBuilder(String.valueOf(message).length() + 42);
                        sb2.append("Failed to retrieve remote module version: ");
                        sb2.append(message);
                        Log.w("DynamiteModule", sb2.toString());
                        return 0;
                    }
                }
                zzo zzoVarZzg = zzg(context);
                if (zzoVarZzg != null) {
                    try {
                        try {
                            int iZzi = zzoVarZzg.zzi();
                            if (iZzi >= 3) {
                                zzm zzmVar = (zzm) zzg.get();
                                if (zzmVar == null || (cursor = zzmVar.zza) == null) {
                                    Cursor cursor3 = (Cursor) ObjectWrapper.unwrap(zzoVarZzg.zzj(ObjectWrapper.wrap(context), str, z, ((Long) zzh.get()).longValue()));
                                    if (cursor3 != null) {
                                        try {
                                            if (cursor3.moveToFirst()) {
                                                int i = cursor3.getInt(0);
                                                cursor2 = (i <= 0 || !zzd(cursor3)) ? cursor3 : null;
                                                if (cursor2 != null) {
                                                    cursor2.close();
                                                }
                                                iZzf = i;
                                            } else {
                                                Log.w("DynamiteModule", "Failed to retrieve remote module version.");
                                                if (cursor3 != null) {
                                                    cursor3.close();
                                                }
                                            }
                                        } catch (RemoteException e3) {
                                            remoteException = e3;
                                            cursor2 = cursor3;
                                            String message2 = remoteException.getMessage();
                                            StringBuilder sb3 = new StringBuilder(String.valueOf(message2).length() + 42);
                                            sb3.append("Failed to retrieve remote module version: ");
                                            sb3.append(message2);
                                            Log.w("DynamiteModule", sb3.toString());
                                            if (cursor2 != null) {
                                                cursor2.close();
                                            }
                                        } catch (Throwable th3) {
                                            th = th3;
                                            cursor2 = cursor3;
                                            if (cursor2 == null) {
                                                throw th;
                                            }
                                            cursor2.close();
                                            throw th;
                                        }
                                    } else {
                                        Log.w("DynamiteModule", "Failed to retrieve remote module version.");
                                        if (cursor3 != null) {
                                            cursor3.close();
                                        }
                                    }
                                } else {
                                    iZzf = cursor.getInt(0);
                                }
                            } else if (iZzi == 2) {
                                Log.w("DynamiteModule", "IDynamite loader version = 2, no high precision latency measurement.");
                                iZzf = zzoVarZzg.zzh(ObjectWrapper.wrap(context), str, z);
                            } else {
                                Log.w("DynamiteModule", "IDynamite loader version < 2, falling back to getModuleVersion2");
                                iZzf = zzoVarZzg.zzf(ObjectWrapper.wrap(context), str, z);
                            }
                        } catch (RemoteException e4) {
                            remoteException = e4;
                        }
                    } catch (Throwable th4) {
                        th = th4;
                    }
                }
                return iZzf;
            }
        } catch (Throwable th5) {
            CrashUtils.addDynamiteErrorToDropBox(context, th5);
            throw th5;
        }
    }

    private static boolean zzb(Context context) {
        ApplicationInfo applicationInfo;
        Boolean bool = Boolean.TRUE;
        if (bool.equals(null) || bool.equals(zzf)) {
            return true;
        }
        boolean z = false;
        if (zzf == null) {
            ProviderInfo providerInfoResolveContentProvider = context.getPackageManager().resolveContentProvider("com.google.android.gms.chimera", true != PlatformVersion.isAtLeastQ() ? 0 : 268435456);
            if (GoogleApiAvailabilityLight.getInstance().isGooglePlayServicesAvailable(context, 10000000) == 0 && providerInfoResolveContentProvider != null && "com.google.android.gms".equals(providerInfoResolveContentProvider.packageName)) {
                z = true;
            }
            zzf = Boolean.valueOf(z);
            if (z && (applicationInfo = providerInfoResolveContentProvider.applicationInfo) != null && (applicationInfo.flags & BuiltinOperator.CALL_ONCE) == 0) {
                Log.i("DynamiteModule", "Non-system-image GmsCore APK, forcing V1");
                zzd = true;
            }
        }
        if (!z) {
            Log.e("DynamiteModule", "Invalid GmsCore APK, remote loading disabled.");
        }
        return z;
    }

    /* JADX WARN: Code duplicated, block: B:101:0x0163 A[Catch: all -> 0x0141, TryCatch #0 {all -> 0x0141, blocks: (B:59:0x00ef, B:61:0x00f5, B:64:0x00fd, B:78:0x012a, B:82:0x0133, B:86:0x0139, B:87:0x0140, B:96:0x014f, B:97:0x015d, B:99:0x015f, B:101:0x0163, B:102:0x0185, B:103:0x0186), top: B:108:0x0003 }] */
    /* JADX WARN: Code duplicated, block: B:103:0x0186 A[Catch: all -> 0x0141, TRY_LEAVE, TryCatch #0 {all -> 0x0141, blocks: (B:59:0x00ef, B:61:0x00f5, B:64:0x00fd, B:78:0x012a, B:82:0x0133, B:86:0x0139, B:87:0x0140, B:96:0x014f, B:97:0x015d, B:99:0x015f, B:101:0x0163, B:102:0x0185, B:103:0x0186), top: B:108:0x0003 }] */
    /* JADX WARN: Code duplicated, block: B:105:0x0189  */
    /* JADX WARN: Code duplicated, block: B:126:? A[SYNTHETIC] */
    /* JADX WARN: Multi-variable type inference failed */
    /* JADX WARN: Not initialized variable reg: 8, insn: 0x0147: MOVE (r2 I:??[OBJECT, ARRAY]) = (r8 I:??[OBJECT, ARRAY]), block:B:92:0x0147 */
    private static int zzc(Context context, String str, boolean z, boolean z2) throws Throwable {
        Throwable th;
        Exception exc;
        Cursor cursor;
        MatrixCursor matrixCursor;
        Cursor cursor2 = null;
        Object[] objArr = 0;
        Object[] objArr2 = 0;
        Object[] objArr3 = 0;
        try {
            try {
                boolean z3 = true;
                Uri uriBuild = new Uri.Builder().scheme("content").authority("com.google.android.gms.chimera").path(true != z ? "api" : "api_force_staging").appendPath(str).appendQueryParameter("requestStartUptime", String.valueOf(((Long) zzh.get()).longValue())).build();
                ContentProviderClient contentProviderClientAcquireUnstableContentProviderClient = context.getContentResolver().acquireUnstableContentProviderClient(uriBuild);
                boolean z4 = false;
                if (contentProviderClientAcquireUnstableContentProviderClient == null) {
                    matrixCursor = null;
                } else {
                    try {
                        Cursor cursorQuery = contentProviderClientAcquireUnstableContentProviderClient.query(uriBuild, null, null, null, null);
                        if (cursorQuery == null) {
                            contentProviderClientAcquireUnstableContentProviderClient.release();
                            matrixCursor = null;
                        } else {
                            try {
                                int count = cursorQuery.getCount();
                                int columnCount = cursorQuery.getColumnCount();
                                matrixCursor = new MatrixCursor(cursorQuery.getColumnNames(), count);
                                for (int i = 0; i < count; i++) {
                                    if (!cursorQuery.moveToPosition(i)) {
                                        throw new RemoteException("Cursor read incomplete (ContentProvider dead?)");
                                    }
                                    Object[] objArr4 = new Object[columnCount];
                                    for (int i2 = 0; i2 < columnCount; i2++) {
                                        int type = cursorQuery.getType(i2);
                                        if (type == 0) {
                                            objArr4[i2] = null;
                                        } else if (type == 1) {
                                            objArr4[i2] = Long.valueOf(cursorQuery.getLong(i2));
                                        } else if (type == 2) {
                                            objArr4[i2] = Double.valueOf(cursorQuery.getDouble(i2));
                                        } else if (type == 3) {
                                            objArr4[i2] = cursorQuery.getString(i2);
                                        } else {
                                            if (type != 4) {
                                                throw new RemoteException("Unknown column type");
                                            }
                                            objArr4[i2] = cursorQuery.getBlob(i2);
                                        }
                                    }
                                    matrixCursor.addRow(objArr4);
                                }
                                cursorQuery.close();
                                contentProviderClientAcquireUnstableContentProviderClient.release();
                            } catch (Throwable th2) {
                                try {
                                    cursorQuery.close();
                                    throw th2;
                                } catch (Throwable th3) {
                                    th2.addSuppressed(th3);
                                    throw th2;
                                }
                            }
                        }
                    } catch (RemoteException unused) {
                    } catch (Throwable th4) {
                        contentProviderClientAcquireUnstableContentProviderClient.release();
                        throw th4;
                    }
                }
                if (matrixCursor != null) {
                    try {
                        if (matrixCursor.moveToFirst()) {
                            int i3 = matrixCursor.getInt(0);
                            if (i3 > 0) {
                                synchronized (DynamiteModule.class) {
                                    try {
                                        zzc = matrixCursor.getString(2);
                                        int columnIndex = matrixCursor.getColumnIndex("loaderVersion");
                                        if (columnIndex >= 0) {
                                            zze = matrixCursor.getInt(columnIndex);
                                        }
                                        int columnIndex2 = matrixCursor.getColumnIndex("disableStandaloneDynamiteLoader2");
                                        if (columnIndex2 >= 0) {
                                            if (matrixCursor.getInt(columnIndex2) == 0) {
                                                z3 = false;
                                            }
                                            zzd = z3;
                                            z4 = z3;
                                        }
                                    } catch (Throwable th5) {
                                        throw th5;
                                    }
                                }
                                if (zzd(matrixCursor)) {
                                    matrixCursor = null;
                                }
                            }
                            if (z2 && z4) {
                                throw new LoadingException("forcing fallback to container DynamiteLoader impl", objArr2 == true ? 1 : 0);
                            }
                            if (matrixCursor != null) {
                                matrixCursor.close();
                            }
                            return i3;
                        }
                    } catch (Exception e) {
                        exc = e;
                        if (!(exc instanceof LoadingException)) {
                            throw exc;
                        }
                        String message = exc.getMessage();
                        StringBuilder sb = new StringBuilder(String.valueOf(message).length() + 25);
                        sb.append("V2 version check failed: ");
                        sb.append(message);
                        throw new LoadingException(sb.toString(), exc, objArr == true ? 1 : 0);
                    }
                }
                Log.w("DynamiteModule", "Failed to retrieve remote module version.");
                throw new LoadingException("Failed to connect to dynamite module ContentResolver.", objArr3 == true ? 1 : 0);
            } catch (Throwable th6) {
                th = th6;
                cursor2 = cursor;
                if (cursor2 != null) {
                    throw th;
                }
                cursor2.close();
                throw th;
            }
        } catch (Exception e2) {
            exc = e2;
            if (!(exc instanceof LoadingException)) {
                throw exc;
            }
            String message2 = exc.getMessage();
            StringBuilder sb2 = new StringBuilder(String.valueOf(message2).length() + 25);
            sb2.append("V2 version check failed: ");
            sb2.append(message2);
            throw new LoadingException(sb2.toString(), exc, objArr == true ? 1 : 0);
        } catch (Throwable th7) {
            th = th7;
            if (cursor2 != null) {
                throw th;
            }
            cursor2.close();
            throw th;
        }
    }

    private static boolean zzd(Cursor cursor) {
        zzm zzmVar = (zzm) zzg.get();
        if (zzmVar == null || zzmVar.zza != null) {
            return false;
        }
        zzmVar.zza = cursor;
        return true;
    }

    private static DynamiteModule zze(Context context, String str) {
        Log.i("DynamiteModule", "Selected local version of ".concat(String.valueOf(str)));
        return new DynamiteModule(context);
    }

    private static void zzf(ClassLoader classLoader) throws LoadingException {
        zzp zzpVar;
        byte[] bArr = null;
        try {
            IBinder iBinder = (IBinder) classLoader.loadClass("com.google.android.gms.dynamiteloader.DynamiteLoaderV2").getConstructor(null).newInstance(null);
            if (iBinder == null) {
                zzpVar = null;
            } else {
                IInterface iInterfaceQueryLocalInterface = iBinder.queryLocalInterface("com.google.android.gms.dynamite.IDynamiteLoaderV2");
                zzpVar = iInterfaceQueryLocalInterface instanceof zzp ? (zzp) iInterfaceQueryLocalInterface : new zzp(iBinder);
            }
            zzl = zzpVar;
        } catch (ClassNotFoundException e) {
            e = e;
            throw new LoadingException("Failed to instantiate dynamite loader", e, bArr);
        } catch (IllegalAccessException e2) {
            e = e2;
            throw new LoadingException("Failed to instantiate dynamite loader", e, bArr);
        } catch (InstantiationException e3) {
            e = e3;
            throw new LoadingException("Failed to instantiate dynamite loader", e, bArr);
        } catch (NoSuchMethodException e4) {
            e = e4;
            throw new LoadingException("Failed to instantiate dynamite loader", e, bArr);
        } catch (InvocationTargetException e5) {
            e = e5;
            throw new LoadingException("Failed to instantiate dynamite loader", e, bArr);
        }
    }

    private static zzo zzg(Context context) {
        zzo zzoVar;
        synchronized (DynamiteModule.class) {
            zzo zzoVar2 = zzk;
            if (zzoVar2 != null) {
                return zzoVar2;
            }
            try {
                IBinder iBinder = (IBinder) context.createPackageContext("com.google.android.gms", 3).getClassLoader().loadClass("com.google.android.gms.chimera.container.DynamiteLoaderImpl").newInstance();
                if (iBinder == null) {
                    zzoVar = null;
                } else {
                    IInterface iInterfaceQueryLocalInterface = iBinder.queryLocalInterface("com.google.android.gms.dynamite.IDynamiteLoader");
                    zzoVar = iInterfaceQueryLocalInterface instanceof zzo ? (zzo) iInterfaceQueryLocalInterface : new zzo(iBinder);
                }
                if (zzoVar != null) {
                    zzk = zzoVar;
                    return zzoVar;
                }
            } catch (Exception e) {
                String message = e.getMessage();
                StringBuilder sb = new StringBuilder(String.valueOf(message).length() + 45);
                sb.append("Failed to load IDynamiteLoader from GmsCore: ");
                sb.append(message);
                Log.e("DynamiteModule", sb.toString());
            }
            return null;
        }
    }

    @KeepForSdk
    public Context getModuleContext() {
        return this.zzj;
    }

    @KeepForSdk
    public IBinder instantiate(String str) throws LoadingException {
        try {
            return (IBinder) this.zzj.getClassLoader().loadClass(str).newInstance();
        } catch (ClassNotFoundException | IllegalAccessException | InstantiationException e) {
            throw new LoadingException("Failed to instantiate module class: ".concat(String.valueOf(str)), e, null);
        }
    }
}
