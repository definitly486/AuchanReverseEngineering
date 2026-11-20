package io.appmetrica.analytics.impl;

import android.content.Context;
import android.database.Cursor;
import android.net.Uri;
import android.text.TextUtils;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.coreutils.internal.services.PackageManagerUtils;
import io.appmetrica.analytics.logger.appmetrica.internal.ImportantLogger;
import java.util.LinkedHashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.jj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0365jj implements InterfaceC0391kj {
    public final Context a;
    public final String b = "content://" + a() + "/clids";
    public final String c = "clid_key";
    public final String d = "clid_value";

    public C0365jj(Context context) {
        this.a = context;
    }

    public final String a() {
        return "com.yandex.preinstallsatellite.appmetrica.provider";
    }

    @Override // kotlin.jvm.functions.Function0
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final I3 invoke() {
        Cursor cursorQuery;
        if (!PackageManagerUtils.hasContentProvider(this.a, "com.yandex.preinstallsatellite.appmetrica.provider")) {
            AbstractC0677vj.a("Satellite content provider with clids was not found.", new Object[0]);
            return null;
        }
        try {
            cursorQuery = this.a.getContentResolver().query(Uri.parse(this.b), null, null, null, null);
            try {
                if (cursorQuery == null) {
                    AbstractC0677vj.a("No Satellite content provider found", new Object[0]);
                    Do.a(cursorQuery);
                    return null;
                }
                LinkedHashMap linkedHashMap = new LinkedHashMap();
                while (cursorQuery.moveToNext()) {
                    try {
                        String string = cursorQuery.getString(cursorQuery.getColumnIndexOrThrow(this.c));
                        String string2 = cursorQuery.getString(cursorQuery.getColumnIndexOrThrow(this.d));
                        if (TextUtils.isEmpty(string) || TextUtils.isEmpty(string2)) {
                            AbstractC0677vj.a("Invalid clid {%s : %s}", string, string2);
                        } else {
                            linkedHashMap.put(string, string2);
                        }
                    } catch (Throwable unused) {
                    }
                }
                AbstractC0677vj.a("Clids from satellite: %s", linkedHashMap);
                I3 i3 = new I3(linkedHashMap, EnumC0406l8.e);
                Do.a(cursorQuery);
                return i3;
            } catch (Throwable th) {
                th = th;
                try {
                    ImportantLogger.INSTANCE.info("AppMetrica-Attribution", String.format("Error while getting satellite clids", new Object[0]) + "\n" + StringUtils.throwableToString(th), new Object[0]);
                } finally {
                    Do.a(cursorQuery);
                }
            }
        } catch (Throwable th2) {
            th = th2;
            cursorQuery = null;
        }
    }
}
