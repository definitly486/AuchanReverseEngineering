package io.appmetrica.analytics.screenshot.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.modulesapi.internal.client.ClientContext;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.w, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0808w implements InterfaceC0795i {
    public final ClientContext a;
    public final Q b;

    public C0808w(ClientContext clientContext, Q q) {
        this.a = clientContext;
        this.b = q;
    }

    @Override // io.appmetrica.analytics.screenshot.impl.InterfaceC0795i
    public final List<P> a() {
        return CollectionsKt.listOf((Object[]) new P[]{new C0790d(this.a, this.b), new C0807v(this.a, this.b), new d0(this.a, this.b)});
    }
}
