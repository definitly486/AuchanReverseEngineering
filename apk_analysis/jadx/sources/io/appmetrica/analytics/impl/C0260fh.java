package io.appmetrica.analytics.impl;

import android.content.Context;
import android.content.pm.FeatureInfo;
import android.content.pm.PackageInfo;
import android.text.TextUtils;
import com.google.mediapipe.framework.AssetCacheDbHelper;
import io.appmetrica.analytics.coreutils.internal.AndroidUtils;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import io.appmetrica.analytics.coreutils.internal.services.SafePackageManager;
import java.util.ArrayList;
import java.util.HashSet;
import org.json.JSONArray;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.fh, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0260fh extends AbstractC0131ah {
    public final SafePackageManager b;

    public C0260fh(C0455n5 c0455n5) {
        this(c0455n5, new SafePackageManager());
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        HashSet hashSet;
        C0455n5 c0455n5 = this.a;
        if (c0455n5.t.c() && c0455n5.y()) {
            C0544qf c0544qf = c0455n5.c;
            String strE = this.a.c.e();
            if (TextUtils.isEmpty(strE)) {
                hashSet = null;
            } else {
                try {
                    hashSet = new HashSet();
                    JSONArray jSONArray = new JSONArray(strE);
                    for (int i = 0; i < jSONArray.length(); i++) {
                        hashSet.add(new C0434ma(jSONArray.getJSONObject(i)));
                    }
                } catch (Throwable unused) {
                    hashSet = null;
                }
            }
            try {
                ArrayList arrayListB = b();
                if (CollectionUtils.areCollectionsEqual(hashSet, arrayListB)) {
                    c0455n5.v();
                } else {
                    JSONArray jSONArray2 = new JSONArray();
                    int size = arrayListB.size();
                    int i2 = 0;
                    while (i2 < size) {
                        Object obj = arrayListB.get(i2);
                        i2++;
                        C0434ma c0434ma = (C0434ma) obj;
                        c0434ma.getClass();
                        JSONObject jSONObjectPut = new JSONObject().put("name", c0434ma.a).put("required", c0434ma.c);
                        int i3 = c0434ma.b;
                        if (i3 != -1) {
                            jSONObjectPut.put(AssetCacheDbHelper.AssetCacheEntry.COLUMN_NAME_VERSION, i3);
                        }
                        jSONArray2.put(jSONObjectPut);
                    }
                    C0249f6 c0249f6A = C0249f6.a(c0249f6, new JSONObject().put("features", jSONArray2).toString());
                    E9 e9 = c0455n5.n;
                    e9.a(c0249f6A, C0393kl.a(e9.c.b(c0249f6A), c0249f6A.i));
                    int i4 = e9.j;
                    e9.l = i4;
                    e9.a.a(i4);
                    c0544qf.i(jSONArray2.toString());
                }
            } catch (Throwable unused2) {
            }
        }
        return false;
    }

    public final ArrayList b() {
        FeatureInfo[] featureInfoArr;
        try {
            C0455n5 c0455n5 = this.a;
            SafePackageManager safePackageManager = this.b;
            Context context = c0455n5.a;
            PackageInfo packageInfo = safePackageManager.getPackageInfo(context, context.getPackageName(), 16384);
            ArrayList arrayList = new ArrayList();
            AbstractC0408la c0356ja = AndroidUtils.isApiAchieved(24) ? new C0356ja() : new C0382ka();
            if (packageInfo != null && (featureInfoArr = packageInfo.reqFeatures) != null) {
                for (FeatureInfo featureInfo : featureInfoArr) {
                    arrayList.add(c0356ja.a(featureInfo));
                }
            }
            return arrayList;
        } catch (Throwable unused) {
            return null;
        }
    }

    public C0260fh(C0455n5 c0455n5, SafePackageManager safePackageManager) {
        super(c0455n5);
        this.b = safePackageManager;
    }
}
