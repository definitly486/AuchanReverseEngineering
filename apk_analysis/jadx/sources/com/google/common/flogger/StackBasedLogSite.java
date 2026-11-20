package com.google.common.flogger;

import com.google.common.flogger.util.Checks;

/* JADX INFO: loaded from: classes2.dex */
final class StackBasedLogSite extends LogSite {
    private final StackTraceElement stackElement;

    public StackBasedLogSite(StackTraceElement stackTraceElement) {
        this.stackElement = (StackTraceElement) Checks.checkNotNull(stackTraceElement, "stack element");
    }

    @Override // com.google.common.flogger.LogSite
    public String getClassName() {
        return this.stackElement.getClassName();
    }

    @Override // com.google.common.flogger.LogSite
    public String getMethodName() {
        return this.stackElement.getMethodName();
    }

    @Override // com.google.common.flogger.LogSite
    public int getLineNumber() {
        return Math.max(this.stackElement.getLineNumber(), 0);
    }

    @Override // com.google.common.flogger.LogSite
    public String getFileName() {
        return this.stackElement.getFileName();
    }

    public boolean equals(Object obj) {
        return (obj instanceof StackBasedLogSite) && this.stackElement.equals(((StackBasedLogSite) obj).stackElement);
    }

    public int hashCode() {
        return this.stackElement.hashCode();
    }
}
