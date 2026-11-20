package io.appmetrica.analytics.impl;

import android.os.Bundle;
import android.os.Parcel;
import android.os.Parcelable;
import android.util.Base64;
import android.util.Pair;
import io.appmetrica.analytics.coreapi.internal.event.CounterReportApi;
import io.appmetrica.analytics.coreapi.internal.permission.PermissionState;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import org.json.JSONArray;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.f6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public class C0249f6 implements CounterReportApi, Parcelable {
    public static final Parcelable.Creator<C0249f6> CREATOR = new C0223e6();
    protected String a;
    protected String b;
    public String c;
    public int d;
    public int e;
    public Pair f;
    public int g;
    public String h;
    public long i;
    public long j;
    public Aa k;
    public G9 l;
    public Bundle m;
    public Boolean n;
    public Integer o;
    public Map p;

    public C0249f6() {
        this("", 0);
    }

    public final void a(String str, String str2) {
        if (this.f == null) {
            this.f = new Pair(str, str2);
        }
    }

    public final Pair<String, String> b() {
        return this.f;
    }

    public final void c(Bundle bundle) {
        this.m = bundle;
    }

    public final long d() {
        return this.i;
    }

    @Override // android.os.Parcelable
    public final int describeContents() {
        return 0;
    }

    public final long e() {
        return this.j;
    }

    public final String f() {
        return this.c;
    }

    public final Aa g() {
        return this.k;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final int getBytesTruncated() {
        return this.g;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final int getCustomType() {
        return this.e;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final Map<String, byte[]> getExtras() {
        return this.p;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final String getName() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final int getType() {
        return this.d;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final String getValue() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final byte[] getValueBytes() {
        String str = this.b;
        if (str == null) {
            return null;
        }
        return Base64.decode(str, 0);
    }

    public final Integer h() {
        return this.o;
    }

    public final Bundle i() {
        return this.m;
    }

    public final String j() {
        return this.h;
    }

    public final G9 k() {
        return this.l;
    }

    public final boolean l() {
        return this.a == null;
    }

    public final boolean m() {
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        return -1 == this.d;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final void setBytesTruncated(int i) {
        this.g = i;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final void setCustomType(int i) {
        this.e = i;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final void setExtras(Map<String, byte[]> map) {
        this.p = map;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public void setName(String str) {
        this.a = str;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public final void setType(int i) {
        this.d = i;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public void setValue(String str) {
        this.b = str;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.event.CounterReportApi
    public void setValueBytes(byte[] bArr) {
        this.b = bArr == null ? null : new String(Base64.encode(bArr, 0));
    }

    public final String toString() {
        Locale locale = Locale.US;
        String str = this.a;
        String str2 = EnumC0721xb.a(this.d).b;
        String strSubstring = this.b;
        if (strSubstring == null) {
            strSubstring = null;
        } else if (strSubstring.length() > 500) {
            strSubstring = strSubstring.substring(0, 500);
        }
        return String.format(locale, "[event: %s, type: %s, value: %s]", str, str2, strSubstring);
    }

    @Override // android.os.Parcelable
    public final void writeToParcel(Parcel parcel, int i) {
        Bundle bundle = new Bundle();
        bundle.putString("CounterReport.Event", this.a);
        bundle.putString("CounterReport.Value", this.b);
        bundle.putInt("CounterReport.Type", this.d);
        bundle.putInt("CounterReport.CustomType", this.e);
        bundle.putInt("CounterReport.TRUNCATED", this.g);
        bundle.putString("CounterReport.ProfileID", this.h);
        bundle.putInt("CounterReport.UniquenessStatus", this.k.a);
        Bundle bundle2 = this.m;
        if (bundle2 != null) {
            bundle.putParcelable("CounterReport.Payload", bundle2);
        }
        String str = this.c;
        if (str != null) {
            bundle.putString("CounterReport.Environment", str);
        }
        Pair pair = this.f;
        if (pair != null) {
            bundle.putString("CounterReport.AppEnvironmentDiffKey", (String) pair.first);
            bundle.putString("CounterReport.AppEnvironmentDiffValue", (String) pair.second);
        }
        bundle.putLong("CounterReport.CreationElapsedRealtime", this.i);
        bundle.putLong("CounterReport.CreationTimestamp", this.j);
        G9 g9 = this.l;
        if (g9 != null) {
            bundle.putInt("CounterReport.Source", g9.a);
        }
        Boolean bool = this.n;
        if (bool != null) {
            bundle.putBoolean("CounterReport.AttributionIdChanged", bool.booleanValue());
        }
        Integer num = this.o;
        if (num != null) {
            bundle.putInt("CounterReport.OpenId", num.intValue());
        }
        bundle.putBundle("CounterReport.Extras", CollectionUtils.mapToBundle(this.p));
        parcel.writeBundle(bundle);
    }

    public C0249f6(String str, int i) {
        this("", str, i);
    }

    public static C0249f6 e(C0249f6 c0249f6) {
        return a(c0249f6, EnumC0721xb.EVENT_TYPE_APP_UPDATE);
    }

    public final void b(String str) {
        this.c = str;
    }

    public void c(String str) {
        this.h = str;
    }

    public final Bundle d(Bundle bundle) {
        if (bundle == null) {
            bundle = new Bundle();
        }
        bundle.putParcelable("CounterReport.Object", this);
        return bundle;
    }

    public C0249f6(String str, String str2, int i) {
        this.k = Aa.UNKNOWN;
        this.p = new HashMap();
        SystemTimeProvider systemTimeProvider = new SystemTimeProvider();
        this.a = str2;
        this.d = i;
        this.b = str;
        this.i = systemTimeProvider.elapsedRealtime();
        this.j = systemTimeProvider.currentTimeMillis();
    }

    public final void a(long j) {
        this.i = j;
    }

    public final void b(long j) {
        this.j = j;
    }

    public final Boolean c() {
        return this.n;
    }

    public static C0249f6 b(Bundle bundle) {
        if (bundle != null) {
            try {
                C0249f6 c0249f6 = (C0249f6) bundle.getParcelable("CounterReport.Object");
                if (c0249f6 != null) {
                    return c0249f6;
                }
            } catch (Throwable unused) {
                return new C0249f6("", 0);
            }
        }
        return new C0249f6("", 0);
    }

    public static C0249f6 c(C0249f6 c0249f6) {
        return a(c0249f6, EnumC0721xb.EVENT_TYPE_INIT);
    }

    public static C0249f6 d(C0249f6 c0249f6) {
        C0249f6 c0249f7 = new C0249f6("", 0);
        c0249f7.j = c0249f6.j;
        c0249f7.i = c0249f6.i;
        c0249f7.f = c0249f6.f;
        c0249f7.c = c0249f6.c;
        c0249f7.m = c0249f6.m;
        c0249f7.p = c0249f6.p;
        c0249f7.h = c0249f6.h;
        return c0249f7;
    }

    public final void a(Aa aa) {
        this.k = aa;
    }

    public final void a(G9 g9) {
        this.l = g9;
    }

    public final void a(Boolean bool) {
        this.n = bool;
    }

    public final void a(Integer num) {
        this.o = num;
    }

    public static Pair a(Bundle bundle) {
        if (bundle.containsKey("CounterReport.AppEnvironmentDiffKey") && bundle.containsKey("CounterReport.AppEnvironmentDiffValue")) {
            return new Pair(bundle.getString("CounterReport.AppEnvironmentDiffKey"), bundle.getString("CounterReport.AppEnvironmentDiffValue"));
        }
        return null;
    }

    public static C0249f6 a(C0249f6 c0249f6, EnumC0721xb enumC0721xb) {
        C0249f6 c0249f6D = d(c0249f6);
        c0249f6D.d = enumC0721xb.a;
        return c0249f6D;
    }

    public static C0249f6 b(C0249f6 c0249f6) {
        return a(c0249f6, EnumC0721xb.EVENT_TYPE_FIRST_ACTIVATION);
    }

    public static C0249f6 a(C0249f6 c0249f6) {
        return a(c0249f6, EnumC0721xb.EVENT_TYPE_ALIVE);
    }

    public static C0249f6 a(C0249f6 c0249f6, C0305ha c0305ha) {
        C0249f6 c0249f6A = a(c0249f6, EnumC0721xb.EVENT_TYPE_START);
        c0249f6A.setValueBytes(MessageNano.toByteArray(new J9().fromModel(new I9((String) c0305ha.b.a()))));
        c0249f6A.j = c0249f6.j;
        c0249f6A.i = c0249f6.i;
        return c0249f6A;
    }

    public static C0249f6 a(C0249f6 c0249f6, Collection<PermissionState> collection, K2 k2, C0504p2 c0504p2, List<String> list) {
        String string;
        String str;
        C0249f6 c0249f6D = d(c0249f6);
        try {
            JSONArray jSONArray = new JSONArray();
            for (PermissionState permissionState : collection) {
                jSONArray.put(new JSONObject().put("name", permissionState.name).put("granted", permissionState.granted));
            }
            JSONObject jSONObject = new JSONObject();
            if (k2 != null) {
                jSONObject.put("background_restricted", k2.b);
                J2 j2 = k2.a;
                c0504p2.getClass();
                if (j2 != null) {
                    int iOrdinal = j2.ordinal();
                    if (iOrdinal == 0) {
                        str = "EXEMPTED";
                    } else if (iOrdinal == 1) {
                        str = "ACTIVE";
                    } else if (iOrdinal == 2) {
                        str = "WORKING_SET";
                    } else if (iOrdinal == 3) {
                        str = "FREQUENT";
                    } else if (iOrdinal == 4) {
                        str = "RARE";
                    } else if (iOrdinal == 5) {
                        str = "RESTRICTED";
                    }
                    jSONObject.put("app_standby_bucket", str);
                }
                str = null;
                jSONObject.put("app_standby_bucket", str);
            }
            string = new JSONObject().put("permissions", jSONArray).put("background_restrictions", jSONObject).put("available_providers", new JSONArray((Collection) list)).toString();
        } catch (Throwable unused) {
            string = "";
        }
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0249f6D.d = 12288;
        c0249f6D.setValue(string);
        return c0249f6D;
    }

    public C0249f6(String str, String str2, int i, long j) {
        this(str, str2, i);
        b(j);
    }

    public static C0249f6 a(C0249f6 c0249f6, String str) {
        C0249f6 c0249f6D = d(c0249f6);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0249f6D.d = 12289;
        c0249f6D.setValue(str);
        return c0249f6D;
    }

    public static C0249f6 a() {
        C0249f6 c0249f6 = new C0249f6("", 0);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0249f6.d = 16384;
        return c0249f6;
    }

    public static C0249f6 a(String str) {
        C0249f6 c0249f6 = new C0249f6("", 0);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        c0249f6.d = 12320;
        c0249f6.b = str;
        c0249f6.l = G9.JS;
        return c0249f6;
    }
}
