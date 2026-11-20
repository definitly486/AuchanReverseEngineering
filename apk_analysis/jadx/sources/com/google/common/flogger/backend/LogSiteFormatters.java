package com.google.common.flogger.backend;

import com.google.common.flogger.LogSite;

/* JADX INFO: loaded from: classes2.dex */
public enum LogSiteFormatters implements LogSiteFormatter {
    DEFAULT { // from class: com.google.common.flogger.backend.LogSiteFormatters.1
        @Override // com.google.common.flogger.backend.LogSiteFormatter
        public boolean appendLogSite(LogSite logSite, StringBuilder sb) {
            if (logSite == LogSite.INVALID) {
                return false;
            }
            sb.append(logSite.getClassName());
            sb.append('.');
            sb.append(logSite.getMethodName());
            sb.append(':');
            sb.append(logSite.getLineNumber());
            return true;
        }
    },
    NO_OP { // from class: com.google.common.flogger.backend.LogSiteFormatters.2
        @Override // com.google.common.flogger.backend.LogSiteFormatter
        public boolean appendLogSite(LogSite logSite, StringBuilder sb) {
            return false;
        }
    },
    SIMPLE_CLASSNAME { // from class: com.google.common.flogger.backend.LogSiteFormatters.3
        @Override // com.google.common.flogger.backend.LogSiteFormatter
        public boolean appendLogSite(LogSite logSite, StringBuilder sb) {
            int i;
            if (logSite == LogSite.INVALID) {
                return false;
            }
            String className = logSite.getClassName();
            int iLastIndexOf = className.lastIndexOf(46);
            if (iLastIndexOf == -1 || (i = iLastIndexOf + 1) >= className.length()) {
                sb.append(className);
            } else {
                sb.append((CharSequence) className, i, className.length());
            }
            sb.append('.');
            sb.append(logSite.getMethodName());
            sb.append(':');
            sb.append(logSite.getLineNumber());
            return true;
        }
    }
}
