package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.FunctionReferenceImpl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.he, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final /* synthetic */ class C0309he extends FunctionReferenceImpl implements Function1 {
    public C0309he(Object obj) {
        super(1, obj, C0335ie.class, "markCrashCompletedAndDeleteCompletedCrashes", "markCrashCompletedAndDeleteCompletedCrashes(Ljava/lang/String;)V", 0);
    }

    @Override // kotlin.jvm.functions.Function1
    public final Object invoke(Object obj) {
        C0335ie c0335ie = (C0335ie) this.receiver;
        c0335ie.a.markCrashCompleted((String) obj);
        c0335ie.a.deleteCompletedCrashes();
        return Unit.INSTANCE;
    }
}
