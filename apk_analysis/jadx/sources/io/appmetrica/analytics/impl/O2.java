package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import io.appmetrica.analytics.ExternalAttribution;
import io.appmetrica.analytics.protobuf.nano.MessageNano;

/* JADX INFO: loaded from: classes3.dex */
public class O2 implements ExternalAttribution {
    public final V9 a;

    public O2(V9 v9) {
        this.a = v9;
    }

    @Override // io.appmetrica.analytics.ExternalAttribution
    public final byte[] toBytes() {
        return MessageNano.toByteArray(this.a);
    }

    public final String toString() {
        return "ExternalAttribution(type=`" + AbstractC0253fa.a(this.a.a) + "`value=`" + new String(this.a.b, Charsets.UTF_8) + "`)";
    }
}
