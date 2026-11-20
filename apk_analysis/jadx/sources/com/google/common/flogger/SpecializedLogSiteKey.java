package com.google.common.flogger;

import com.google.common.flogger.util.Checks;

/* JADX INFO: loaded from: classes2.dex */
final class SpecializedLogSiteKey implements LogSiteKey {
    private final LogSiteKey delegate;
    private final Object qualifier;

    static LogSiteKey of(LogSiteKey logSiteKey, Object obj) {
        return new SpecializedLogSiteKey(logSiteKey, obj);
    }

    private SpecializedLogSiteKey(LogSiteKey logSiteKey, Object obj) {
        this.delegate = (LogSiteKey) Checks.checkNotNull(logSiteKey, "log site key");
        this.qualifier = Checks.checkNotNull(obj, "log site qualifier");
    }

    public boolean equals(Object obj) {
        if (!(obj instanceof SpecializedLogSiteKey)) {
            return false;
        }
        SpecializedLogSiteKey specializedLogSiteKey = (SpecializedLogSiteKey) obj;
        return this.delegate.equals(specializedLogSiteKey.delegate) && this.qualifier.equals(specializedLogSiteKey.qualifier);
    }

    public int hashCode() {
        return this.delegate.hashCode() ^ this.qualifier.hashCode();
    }

    public String toString() {
        return "SpecializedLogSiteKey{ delegate='" + this.delegate + "', qualifier='" + this.qualifier + "' }";
    }
}
