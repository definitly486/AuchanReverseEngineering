package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import java.util.ArrayList;
import java.util.Iterator;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.zf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0777zf implements ProtobufConverter {
    public final Lf a;
    public final C0647uf b;

    public C0777zf() {
        this(new Lf(), new C0647uf());
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Hf fromModel(C0725xf c0725xf) {
        Hf hf = new Hf();
        hf.a = this.a.fromModel(c0725xf.a);
        hf.b = new Gf[c0725xf.b.size()];
        Iterator<C0699wf> it = c0725xf.b.iterator();
        int i = 0;
        while (it.hasNext()) {
            hf.b[i] = this.b.fromModel(it.next());
            i++;
        }
        return hf;
    }

    public C0777zf(Lf lf, C0647uf c0647uf) {
        this.a = lf;
        this.b = c0647uf;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0725xf toModel(Hf hf) {
        Kf model;
        ArrayList arrayList = new ArrayList(hf.b.length);
        for (Gf gf : hf.b) {
            arrayList.add(this.b.toModel(gf));
        }
        Ff ff = hf.a;
        if (ff == null) {
            model = this.a.toModel(new Ff());
        } else {
            model = this.a.toModel(ff);
        }
        return new C0725xf(model, arrayList);
    }
}
