package com.scanflow.datacapture.barinternal.e;

import android.app.Activity;
import android.os.Build;
import android.provider.Settings;
import com.scanflow.datacapture.barinternal.kotlin.text.CharsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import com.scanflow.datacapture.model.DeviceInfo;
import java.util.Locale;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public abstract class b {
    public static DeviceInfo a(Activity mActivity, String productType) {
        String strValueOf;
        Intrinsics.checkNotNullParameter(mActivity, "mActivity");
        Intrinsics.checkNotNullParameter(productType, "productType");
        String packageName = mActivity.getPackageName();
        String string = Settings.Secure.getString(mActivity.getContentResolver(), "android_id");
        DeviceInfo deviceInfo = new DeviceInfo(null, null, null, null, null, null, 63, null);
        String MODEL = Build.MODEL;
        Intrinsics.checkNotNullExpressionValue(MODEL, "MODEL");
        String MANUFACTURER = Build.MANUFACTURER;
        Intrinsics.checkNotNullExpressionValue(MANUFACTURER, "MANUFACTURER");
        if (!StringsKt.startsWith(MODEL, MANUFACTURER, true)) {
            MODEL = MANUFACTURER + ' ' + MODEL;
        }
        Intrinsics.checkNotNull(MODEL);
        if (MODEL.length() > 0) {
            StringBuilder sb = new StringBuilder();
            char cCharAt = MODEL.charAt(0);
            if (Character.isLowerCase(cCharAt)) {
                Locale ROOT = Locale.ROOT;
                Intrinsics.checkNotNullExpressionValue(ROOT, "ROOT");
                strValueOf = CharsKt.titlecase(cCharAt, ROOT);
            } else {
                strValueOf = String.valueOf(cCharAt);
            }
            sb.append((Object) strValueOf);
            String strSubstring = MODEL.substring(1);
            Intrinsics.checkNotNullExpressionValue(strSubstring, "substring(...)");
            sb.append(strSubstring);
            MODEL = sb.toString();
        }
        deviceInfo.setDeviceMake(MODEL);
        deviceInfo.setOsVersion(String.valueOf(Build.VERSION.RELEASE));
        deviceInfo.setDeviceModel(Build.DEVICE);
        deviceInfo.setBundleId(packageName);
        deviceInfo.setDeviceId(string);
        deviceInfo.setProductType(productType);
        return deviceInfo;
    }
}
