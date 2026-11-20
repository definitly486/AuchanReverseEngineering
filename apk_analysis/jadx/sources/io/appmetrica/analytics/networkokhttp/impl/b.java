package io.appmetrica.analytics.networkokhttp.impl;

import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Lambda;
import okhttp3.Response;
import okhttp3.ResponseBody;

/* JADX INFO: loaded from: classes3.dex */
public final class b extends Lambda implements Function0 {
    public final /* synthetic */ Response a;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public b(Response response) {
        super(0);
        this.a = response;
    }

    @Override // kotlin.jvm.functions.Function0
    public final Object invoke() {
        ResponseBody responseBodyBody = this.a.body();
        if (responseBodyBody != null) {
            return responseBodyBody.byteStream();
        }
        return null;
    }
}
