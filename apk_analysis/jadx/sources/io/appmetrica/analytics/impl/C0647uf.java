package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.uf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0647uf implements ProtobufConverter {
    public final Jf a;

    public C0647uf() {
        this(new Jf());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Gf fromModel(C0699wf c0699wf) {
        Gf gf = new Gf();
        if (!StringUtils.isNullOrEmpty(c0699wf.a)) {
            gf.a = c0699wf.a;
        }
        gf.b = c0699wf.b.toString();
        gf.c = this.a.fromModel(c0699wf.c).intValue();
        return gf;
    }

    public C0647uf(Jf jf) {
        this.a = jf;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0699wf toModel(Gf gf) {
        JSONObject jSONObject;
        String str = gf.a;
        String str2 = gf.b;
        if (!StringUtils.isNullOrEmpty(str2)) {
            try {
                jSONObject = new JSONObject(str2);
            } catch (Throwable unused) {
                jSONObject = new JSONObject();
            }
        } else {
            jSONObject = new JSONObject();
        }
        return new C0699wf(str, jSONObject, this.a.toModel(Integer.valueOf(gf.c)));
    }
}
