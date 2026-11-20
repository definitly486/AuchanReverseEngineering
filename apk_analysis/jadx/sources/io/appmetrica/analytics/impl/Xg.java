package io.appmetrica.analytics.impl;

import android.net.Uri;
import android.text.TextUtils;
import android.util.Pair;
import io.appmetrica.analytics.coreapi.internal.data.IBinaryDataHelper;
import java.util.HashSet;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Xg extends AbstractC0131ah {
    public Xg(C0455n5 c0455n5) {
        super(c0455n5);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        String value = c0249f6.getValue();
        if (TextUtils.isEmpty(value)) {
            return false;
        }
        try {
            JSONObject jSONObject = new JSONObject(value);
            if (!"open".equals(jSONObject.optString("type"))) {
                return false;
            }
            Po po = this.a.t;
            synchronized (po) {
                po.c(po.b() + 1);
            }
            if (!a(jSONObject.optString("link"))) {
                return false;
            }
            c0249f6.n = Boolean.TRUE;
            b();
            return false;
        } catch (Throwable unused) {
            return false;
        }
    }

    public final void b() {
        Po po = this.a.t;
        synchronized (po) {
            po.a(po.a() + 1);
        }
        this.a.z();
        C0278g9 c0278g9 = this.a.l;
        if (c0278g9.c == null) {
            c0278g9.a();
        }
        C0330i9 c0330i9 = c0278g9.c;
        c0330i9.getClass();
        c0330i9.b = new HashSet();
        c0330i9.d = 0;
        C0330i9 c0330i10 = c0278g9.c;
        c0330i10.a = true;
        C0407l9 c0407l9 = c0278g9.b;
        IBinaryDataHelper iBinaryDataHelper = c0407l9.c;
        C0381k9 c0381k9 = c0407l9.b;
        c0407l9.a.getClass();
        iBinaryDataHelper.insert("event_hashes", c0381k9.toByteArray(C0355j9.a(c0330i10)));
    }

    public final boolean a(String str) {
        if (!TextUtils.isEmpty(str)) {
            try {
                String queryParameter = Uri.parse(str).getQueryParameter("referrer");
                if (!TextUtils.isEmpty(queryParameter)) {
                    C0764z2 c0764z2 = this.a.t().y;
                    for (String str2 : Uri.decode(queryParameter).split("&")) {
                        String strDecode = Uri.decode(str2);
                        int iIndexOf = strDecode.indexOf("=");
                        if (iIndexOf >= 0 && a(Uri.decode(strDecode.substring(0, iIndexOf)), Uri.decode(strDecode.substring(iIndexOf + 1)), c0764z2)) {
                            return true;
                        }
                    }
                }
            } catch (Throwable unused) {
            }
        }
        return false;
    }

    public static boolean a(String str, String str2, C0764z2 c0764z2) {
        Object obj;
        if ("reattribution".equals(str) && "1".equals(str2)) {
            return true;
        }
        if (c0764z2 == null) {
            return false;
        }
        for (Pair pair : c0764z2.a) {
            if (Do.a(pair.first, str) && ((obj = pair.second) == null || ((C0738y2) obj).a.equals(str2))) {
                return true;
            }
        }
        return false;
    }
}
