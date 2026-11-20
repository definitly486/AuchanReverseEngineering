package com.google.android.gms.common;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.pm.Signature;
import android.content.pm.SigningInfo;
import android.os.Build;
import android.os.RemoteException;
import android.os.StrictMode;
import android.util.Log;
import com.google.android.gms.common.annotation.KeepForSdk;
import com.google.android.gms.common.internal.Preconditions;
import com.google.android.gms.common.internal.ShowFirstParty;
import com.google.android.gms.common.util.AndroidUtilsLight;
import com.google.android.gms.dynamite.DynamiteModule;
import com.google.android.gms.internal.common.zzaf;
import com.google.android.gms.internal.common.zzaj;
import com.google.android.gms.internal.common.zzan;
import java.util.Arrays;
import java.util.Set;
import org.tensorflow.lite.schema.BuiltinOperator;

/* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
/* JADX INFO: loaded from: classes.dex */
@ShowFirstParty
@KeepForSdk
public class GoogleSignatureVerifier {
    private static GoogleSignatureVerifier zza;
    private static volatile Set zzd;
    private static volatile Set zze;
    private final Context zzb;
    private volatile String zzc;

    public GoogleSignatureVerifier(Context context) {
        this.zzb = context.getApplicationContext();
    }

    @KeepForSdk
    public static GoogleSignatureVerifier getInstance(Context context) {
        Preconditions.checkNotNull(context);
        synchronized (GoogleSignatureVerifier.class) {
            try {
                if (zza == null) {
                    zzo.zza(context);
                    zza = new GoogleSignatureVerifier(context);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return zza;
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Deprecated
    static final boolean zza(PackageInfo packageInfo, boolean z) {
        zzaj zzajVarZzj;
        if (packageInfo == null) {
            return false;
        }
        if (z && ("com.android.vending".equals(packageInfo.packageName) || "com.google.android.gms".equals(packageInfo.packageName))) {
            ApplicationInfo applicationInfo = packageInfo.applicationInfo;
            z = (applicationInfo == null || (applicationInfo.flags & BuiltinOperator.CALL_ONCE) == 0) ? false : true;
        }
        try {
            zzaj zzajVar = z ? zzn.zzc : zzn.zzb;
            int i = AndroidUtilsLight.zza;
            int i2 = Build.VERSION.SDK_INT;
            if (i2 < 28) {
                Signature[] signatureArr = packageInfo.signatures;
                byte[] byteArray = null;
                if (signatureArr != null && signatureArr.length == 1) {
                    byteArray = signatureArr[0].toByteArray();
                }
                zzajVarZzj = byteArray != null ? zzaj.zzk(byteArray) : zzaj.zzj();
            } else {
                com.google.android.gms.internal.common.zzt.zza(i2 >= 28);
                SigningInfo signingInfo = packageInfo.signingInfo;
                if (signingInfo == null || signingInfo.hasMultipleSigners() || signingInfo.getSigningCertificateHistory() == null) {
                    zzajVarZzj = zzaj.zzj();
                } else {
                    int i3 = zzaj.zzd;
                    zzaf zzafVar = new zzaf();
                    for (Signature signature : signingInfo.getSigningCertificateHistory()) {
                        zzafVar.zzb(signature.toByteArray());
                    }
                    zzajVarZzj = zzafVar.zzd();
                }
            }
            if (zzajVarZzj.isEmpty()) {
                throw new IllegalArgumentException("Unable to obtain package certificate history.");
            }
            zzaj zzajVarZzh = zzajVarZzj.zzh();
            int size = zzajVarZzh.size();
            int i4 = 0;
            while (i4 < size) {
                byte[] bArr = (byte[]) zzajVarZzh.get(i4);
                zzan zzanVarListIterator = zzajVar.listIterator(0);
                do {
                    int i5 = i4 + 1;
                    if (!zzanVarListIterator.hasNext()) {
                        i4 = i5;
                    }
                } while (!Arrays.equals(bArr, (byte[]) zzanVarListIterator.next()));
                return true;
            }
            return false;
        } catch (IllegalArgumentException unused) {
            Log.i("GoogleSignatureVerifier", "package info is not set correctly");
            return (z ? zzc(packageInfo, zzn.zza) : zzc(packageInfo, zzn.zza[0])) != null;
        }
    }

    /* JADX WARN: Multi-variable type inference failed */
    /* JADX WARN: Type inference failed for: r8v4, types: [android.os.StrictMode$ThreadPolicy] */
    /* JADX WARN: Type inference failed for: r8v6, types: [int] */
    @SuppressLint({"PackageManagerGetSignatures"})
    private final zzy zzb(String str, boolean z, boolean z2) {
        zzy zzyVarZzc;
        ApplicationInfo applicationInfo;
        if (str == null) {
            return zzy.zzc("null pkg");
        }
        if (str.equals(this.zzc)) {
            return zzy.zzb();
        }
        int i = zzo.zzh;
        StrictMode.ThreadPolicy threadPolicyAllowThreadDiskReads = StrictMode.allowThreadDiskReads();
        try {
            try {
                zzo.zzb();
                boolean zZzg = zzo.zzg.zzg();
                StrictMode.setThreadPolicy(threadPolicyAllowThreadDiskReads);
                if (zZzg) {
                    zzv zzvVar = new zzv(null);
                    zzvVar.zza(str);
                    zzvVar.zzb(GooglePlayServicesUtilLight.honorsDebugCertificates(this.zzb));
                    zzvVar.zzc(true);
                    zzyVarZzc = zzo.zzc(zzvVar.zzd());
                } else {
                    threadPolicyAllowThreadDiskReads = Build.VERSION.SDK_INT;
                    try {
                        PackageInfo packageInfo = this.zzb.getPackageManager().getPackageInfo(str, threadPolicyAllowThreadDiskReads >= 28 ? 134217792 : 64);
                        boolean zHonorsDebugCertificates = GooglePlayServicesUtilLight.honorsDebugCertificates(this.zzb);
                        if (packageInfo == null) {
                            zzyVarZzc = zzy.zzc("null pkg");
                        } else {
                            Signature[] signatureArr = packageInfo.signatures;
                            if (signatureArr == null || signatureArr.length != 1) {
                                zzyVarZzc = zzy.zzc("single cert required");
                            } else {
                                zzk zzkVar = new zzk(packageInfo.signatures[0].toByteArray());
                                String str2 = packageInfo.packageName;
                                zzy zzyVarZzd = zzo.zzd(str2, zzkVar, zHonorsDebugCertificates, false);
                                zzyVarZzc = (!zzyVarZzd.zza || (applicationInfo = packageInfo.applicationInfo) == null || (applicationInfo.flags & 2) == 0 || !zzo.zzd(str2, zzkVar, false, true).zza) ? zzyVarZzd : zzy.zzc("debuggable release cert app rejected");
                            }
                        }
                    } catch (PackageManager.NameNotFoundException e) {
                        return zzy.zzd("no pkg ".concat(str), e);
                    }
                }
            } catch (Throwable th) {
                StrictMode.setThreadPolicy(threadPolicyAllowThreadDiskReads);
                throw th;
            }
        } catch (RemoteException | DynamiteModule.LoadingException e2) {
            Log.e("GoogleCertificates", "Failed to get Google certificates from remote", e2);
            StrictMode.setThreadPolicy(threadPolicyAllowThreadDiskReads);
        }
        if (zzyVarZzc.zza) {
            this.zzc = str;
        }
        return zzyVarZzc;
    }

    private static zzj zzc(PackageInfo packageInfo, zzj... zzjVarArr) {
        Signature[] signatureArr = packageInfo.signatures;
        if (signatureArr != null) {
            if (signatureArr.length != 1) {
                Log.w("GoogleSignatureVerifier", "Package has more than one signature.");
                return null;
            }
            zzk zzkVar = new zzk(packageInfo.signatures[0].toByteArray());
            for (int i = 0; i < zzjVarArr.length; i++) {
                if (zzjVarArr[i].equals(zzkVar)) {
                    return zzjVarArr[i];
                }
            }
        }
        return null;
    }

    @KeepForSdk
    public boolean isGooglePublicSignedPackage(PackageInfo packageInfo) {
        if (packageInfo == null) {
            return false;
        }
        if (zza(packageInfo, false)) {
            return true;
        }
        if (zza(packageInfo, true)) {
            if (GooglePlayServicesUtilLight.honorsDebugCertificates(this.zzb)) {
                return true;
            }
            Log.w("GoogleSignatureVerifier", "Test-keys aren't accepted on this build.");
        }
        return false;
    }

    @ShowFirstParty
    @KeepForSdk
    public boolean isPackageGoogleSigned(String str) {
        zzy zzyVarZzb = zzb(str, false, false);
        zzyVarZzb.zze();
        return zzyVarZzb.zza;
    }

    @ShowFirstParty
    @KeepForSdk
    public boolean isUidGoogleSigned(int i) {
        zzy zzyVarZzc;
        String[] packagesForUid = this.zzb.getPackageManager().getPackagesForUid(i);
        if (packagesForUid == null || (packagesForUid.length) == 0) {
            zzyVarZzc = zzy.zzc("no pkgs");
        } else {
            zzyVarZzc = null;
            for (String str : packagesForUid) {
                zzyVarZzc = zzb(str, false, false);
                if (!zzyVarZzc.zza) {
                }
            }
            Preconditions.checkNotNull(zzyVarZzc);
        }
        zzyVarZzc.zze();
        return zzyVarZzc.zza;
    }
}
