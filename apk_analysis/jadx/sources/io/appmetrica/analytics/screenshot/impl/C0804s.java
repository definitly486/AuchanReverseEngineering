package io.appmetrica.analytics.screenshot.impl;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.s, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0804s extends Lambda implements Function0 {
    public final /* synthetic */ C0807v a;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public C0804s(C0807v c0807v) {
        super(0);
        this.a = c0807v;
    }

    @Override // kotlin.jvm.functions.Function0
    public final Object invoke() {
        ((C0809x) this.a.b).a("ContentObserverScreenshotCaptor");
        return Unit.INSTANCE;
    }
}
