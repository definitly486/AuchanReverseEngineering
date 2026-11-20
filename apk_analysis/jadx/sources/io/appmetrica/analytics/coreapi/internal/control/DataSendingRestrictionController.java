package io.appmetrica.analytics.coreapi.internal.control;

/* JADX INFO: loaded from: classes3.dex */
public interface DataSendingRestrictionController {
    boolean isRestrictedForMainReporter();

    boolean isRestrictedForReporter(String str);

    boolean isRestrictedForSdk();
}
