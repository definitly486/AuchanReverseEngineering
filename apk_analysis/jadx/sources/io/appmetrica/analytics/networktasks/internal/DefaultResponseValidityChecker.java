package io.appmetrica.analytics.networktasks.internal;

/* JADX INFO: loaded from: classes3.dex */
public final class DefaultResponseValidityChecker implements ResponseValidityChecker {
    @Override // io.appmetrica.analytics.networktasks.internal.ResponseValidityChecker
    public boolean isResponseValid(int i) {
        return (i == 400 || i == 500) ? false : true;
    }
}
