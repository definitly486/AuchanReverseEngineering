package com.google.common.flogger.backend;

import com.google.common.flogger.LogSite;
import com.google.errorprone.annotations.CanIgnoreReturnValue;

/* JADX INFO: loaded from: classes2.dex */
public interface LogSiteFormatter {
    @CanIgnoreReturnValue
    boolean appendLogSite(LogSite logSite, StringBuilder sb);
}
