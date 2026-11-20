package io.appmetrica.analytics.impl;

import android.content.Context;
import android.location.Location;
import android.net.ConnectivityManager;
import io.appmetrica.analytics.coreapi.internal.system.NetworkType;
import io.appmetrica.analytics.coreutils.internal.system.SystemServiceUtils;
import kotlin.jvm.internal.Ref$ObjectRef;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.y7, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0743y7 {
    public final Context a;
    public final int b;
    public final Po c;
    public final S8 d;
    public final C0372k0 e;
    public final C0201d9 f;
    public final B7 g;
    public final C0249f6 h;

    public C0743y7(Context context, C0471nl c0471nl, int i, Po po, S8 s8, C0372k0 c0372k0, C0201d9 c0201d9, B7 b7) {
        this.a = context;
        this.b = i;
        this.c = po;
        this.d = s8;
        this.e = c0372k0;
        this.f = c0201d9;
        this.g = b7;
        this.h = s8.a;
    }

    public static String b() {
        Ref$ObjectRef ref$ObjectRef = new Ref$ObjectRef();
        En enC = Ka.I.C();
        C0717x7 c0717x7 = new C0717x7(ref$ObjectRef);
        synchronized (enC) {
            enC.b.a(c0717x7);
        }
        return (String) ref$ObjectRef.element;
    }

    public final C0639u7 a() {
        long jOptLong;
        bp bpVar;
        Integer numValueOf = Integer.valueOf(this.h.e);
        String name = this.h.getName();
        String value = this.h.getValue();
        Po po = this.c;
        int i = this.b;
        synchronized (po) {
            try {
                JSONObject jSONObjectA = po.a.a();
                JSONObject jSONObjectOptJSONObject = jSONObjectA.optJSONObject("numbers_of_type");
                if (jSONObjectOptJSONObject == null) {
                    jSONObjectOptJSONObject = new JSONObject();
                }
                jOptLong = jSONObjectOptJSONObject.optLong(String.valueOf(i));
                jSONObjectOptJSONObject.put(String.valueOf(i), 1 + jOptLong);
                po.a.a(jSONObjectA.put("numbers_of_type", jSONObjectOptJSONObject));
            } catch (Throwable th) {
                throw th;
            }
        }
        Long lValueOf = Long.valueOf(jOptLong);
        B7 b7 = this.g;
        b7.getClass();
        InterfaceC0281gc interfaceC0281gcM = Ka.I.m();
        Location userLocation = interfaceC0281gcM.getUserLocation();
        if (userLocation != null) {
            int i2 = bp.b;
            Location location = new Location(userLocation);
            String provider = location.getProvider();
            location.setProvider("");
            bpVar = new bp(location, provider);
        } else {
            Location systemLocation = interfaceC0281gcM.getSystemLocation();
            bpVar = systemLocation != null ? new bp(new Location(systemLocation), "") : null;
        }
        boolean z = b7.a.d;
        Double dValueOf = bpVar != null ? Double.valueOf(bpVar.getLatitude()) : null;
        Double dValueOf2 = bpVar != null ? Double.valueOf(bpVar.getLongitude()) : null;
        Long lValueOf2 = bpVar != null ? Long.valueOf(bpVar.getTime()) : null;
        Integer numValueOf2 = bpVar != null ? Integer.valueOf((int) bpVar.getAccuracy()) : null;
        Integer numValueOf3 = bpVar != null ? Integer.valueOf((int) bpVar.getBearing()) : null;
        Integer numValueOf4 = bpVar != null ? Integer.valueOf((int) bpVar.getSpeed()) : null;
        C0769z7 c0769z7 = new C0769z7(Boolean.valueOf(z), dValueOf2, dValueOf, bpVar != null ? Integer.valueOf((int) bpVar.getAltitude()) : null, numValueOf3, numValueOf2, numValueOf4, lValueOf2, bpVar != null ? bpVar.getProvider() : null, bpVar != null ? bpVar.a : null);
        String str = this.h.c;
        C0372k0 c0372k0 = this.e;
        String str2 = c0372k0.a;
        Long lValueOf3 = Long.valueOf(c0372k0.b);
        Integer numValueOf5 = Integer.valueOf(this.h.g);
        Context context = this.a;
        Xe xe = AbstractC0155bf.a;
        Integer num = (Integer) AbstractC0155bf.c.a((NetworkType) SystemServiceUtils.accessSystemServiceSafelyOrDefault((ConnectivityManager) context.getSystemService("connectivity"), "getting connection type", "ConnectivityManager", NetworkType.UNDEFINED, new C0129af()));
        num.intValue();
        String strB = b();
        EnumC0175c9 enumC0175c9 = this.d.b;
        C0249f6 c0249f6 = this.h;
        return new C0639u7(numValueOf, name, value, lValueOf, c0769z7, str, str2, lValueOf3, numValueOf5, num, strB, enumC0175c9, c0249f6.h, c0249f6.k, c0249f6.l, c0249f6.n, c0249f6.o, this.f.fromModel(c0249f6.p));
    }

    public /* synthetic */ C0743y7(Context context, C0471nl c0471nl, int i, Po po, S8 s8, C0727xh c0727xh, C0372k0 c0372k0) {
        this(context, c0471nl, i, po, s8, c0372k0, new C0201d9(), new B7(c0727xh));
    }
}
