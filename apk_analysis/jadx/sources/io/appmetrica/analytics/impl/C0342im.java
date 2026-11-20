package io.appmetrica.analytics.impl;

import android.text.TextUtils;
import com.bumptech.glide.load.Key;
import com.google.common.net.HttpHeaders;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import io.appmetrica.analytics.networktasks.internal.NetworkResponseHandler;
import io.appmetrica.analytics.networktasks.internal.ResponseDataHolder;
import java.util.Collection;
import java.util.List;
import java.util.Map;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.im, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0342im implements NetworkResponseHandler {
    public final C0524pm a;
    public final C0324i3 b;

    public C0342im() {
        this(new C0524pm(), new C0324i3());
    }

    @Override // io.appmetrica.analytics.networktasks.internal.NetworkResponseHandler
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0654um handle(ResponseDataHolder responseDataHolder) {
        String strOptString;
        String strOptString2;
        if (200 == responseDataHolder.getResponseCode()) {
            byte[] responseData = responseDataHolder.getResponseData();
            Map<String, List<String>> responseHeaders = responseDataHolder.getResponseHeaders();
            List list = responseHeaders != null ? (List) CollectionUtils.getFromMapIgnoreCase(responseHeaders, HttpHeaders.CONTENT_ENCODING) : null;
            if (!Do.a((Collection) list) && "encrypted".equals(list.get(0))) {
                responseData = this.b.a(responseDataHolder.getResponseData());
            }
            if (responseData != null) {
                C0524pm c0524pm = this.a;
                c0524pm.getClass();
                C0654um c0654um = new C0654um();
                try {
                    c0524pm.h.getClass();
                    Bb bb = new Bb(new String(responseData, Key.STRING_CHARSET_NAME));
                    JSONObject jSONObjectOptJSONObject = bb.optJSONObject("device_id");
                    if (jSONObjectOptJSONObject != null) {
                        strOptString = jSONObjectOptJSONObject.optString("hash");
                        strOptString2 = jSONObjectOptJSONObject.optString("value");
                    } else {
                        strOptString = "";
                        strOptString2 = "";
                    }
                    c0654um.h = strOptString2;
                    c0654um.i = strOptString;
                    c0524pm.a(c0654um, bb);
                    c0654um.a = TextUtils.isEmpty(c0654um.i) ? 1 : 2;
                } catch (Throwable unused) {
                    c0654um = new C0654um();
                    c0654um.a = 1;
                }
                if (2 == c0654um.a) {
                    return c0654um;
                }
            }
        }
        return null;
    }

    public C0342im(C0524pm c0524pm, C0324i3 c0324i3) {
        this.a = c0524pm;
        this.b = c0324i3;
    }
}
