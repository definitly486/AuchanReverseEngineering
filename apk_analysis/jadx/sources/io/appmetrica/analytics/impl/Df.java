package io.appmetrica.analytics.impl;

import android.content.Context;
import android.database.Cursor;
import android.net.Uri;
import android.text.TextUtils;
import io.appmetrica.analytics.coreutils.internal.parsing.ParseUtils;
import io.appmetrica.analytics.coreutils.internal.services.PackageManagerUtils;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Df implements InterfaceC0391kj {
    public final Context a;
    public final String b = "content://" + a() + "/preload_info";
    public final String c = "tracking_id";
    public final String d = "additional_parameters";

    public Df(Context context) {
        this.a = context;
    }

    public final String a() {
        return "com.yandex.preinstallsatellite.appmetrica.provider";
    }

    @Override // kotlin.jvm.functions.Function0
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final Kf invoke() {
        Cursor cursorQuery;
        JSONObject jSONObject;
        if (!PackageManagerUtils.hasContentProvider(this.a, "com.yandex.preinstallsatellite.appmetrica.provider")) {
            AbstractC0677vj.a("Satellite content provider with preload info was not found.", new Object[0]);
            return null;
        }
        try {
            cursorQuery = this.a.getContentResolver().query(Uri.parse(this.b), null, null, null, null);
            try {
                if (cursorQuery == null) {
                    AbstractC0677vj.a("No Satellite content provider found", new Object[0]);
                } else {
                    if (cursorQuery.moveToFirst()) {
                        String string = cursorQuery.getString(cursorQuery.getColumnIndexOrThrow(this.c));
                        String string2 = cursorQuery.getString(cursorQuery.getColumnIndexOrThrow(this.d));
                        if (string2 == null) {
                            JSONObject jSONObject2 = jSONObject;
                            if (!TextUtils.isEmpty(string)) {
                                AbstractC0677vj.a("Tracking id from Satellite is not a number.", new Object[0]);
                            }
                            AbstractC0677vj.a("Preload info from Satellite: {tracking id = %s, additional parameters = %s}", string, jSONObject2);
                            Kf kf = new Kf(string, jSONObject2, !TextUtils.isEmpty(string), false, EnumC0406l8.e);
                            Do.a(cursorQuery);
                            return kf;
                        }
                        try {
                            jSONObject = string2.length() == 0 ? new JSONObject() : new JSONObject(string2);
                        } catch (Throwable unused) {
                            jSONObject = new JSONObject();
                        }
                        JSONObject jSONObject3 = jSONObject;
                        if (!TextUtils.isEmpty(string) && ParseUtils.parseLong(string) == null) {
                            AbstractC0677vj.a("Tracking id from Satellite is not a number.", new Object[0]);
                        }
                        AbstractC0677vj.a("Preload info from Satellite: {tracking id = %s, additional parameters = %s}", string, jSONObject3);
                        Kf kf2 = new Kf(string, jSONObject3, !TextUtils.isEmpty(string), false, EnumC0406l8.e);
                        Do.a(cursorQuery);
                        return kf2;
                    }
                    AbstractC0677vj.a("No Preload Info data in Satellite content provider", new Object[0]);
                }
            } catch (Throwable unused2) {
            }
        } catch (Throwable unused3) {
            cursorQuery = null;
        }
        Do.a(cursorQuery);
        return null;
    }
}
