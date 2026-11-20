package com.google.common.flogger;

import com.google.common.flogger.util.Checks;
import java.io.File;
import okhttp3.internal.http2.Settings;

/* JADX INFO: loaded from: classes2.dex */
public abstract class LogSite implements LogSiteKey {
    public static final LogSite INVALID = new LogSite() { // from class: com.google.common.flogger.LogSite.1
        @Override // com.google.common.flogger.LogSite
        public String getFileName() {
            return null;
        }

        @Override // com.google.common.flogger.LogSite
        public int getLineNumber() {
            return 0;
        }

        @Override // com.google.common.flogger.LogSite
        public String getClassName() {
            return "<unknown class>";
        }

        @Override // com.google.common.flogger.LogSite
        public String getMethodName() {
            return "<unknown method>";
        }
    };
    public static final int UNKNOWN_LINE = 0;

    public abstract String getClassName();

    public abstract String getFileName();

    public abstract int getLineNumber();

    public abstract String getMethodName();

    public final String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("LogSite{ class=");
        sb.append(getClassName());
        sb.append(", method=");
        sb.append(getMethodName());
        sb.append(", line=");
        sb.append(getLineNumber());
        if (getFileName() != null) {
            sb.append(", file=");
            sb.append(getFileName());
        }
        sb.append(" }");
        return sb.toString();
    }

    @Deprecated
    public static LogSite injectedLogSite(String str, String str2, int i, String str3) {
        return new InjectedLogSite(str, str2, i, str3);
    }

    private static final class InjectedLogSite extends LogSite {
        private final int encodedLineNumber;
        private int hashcode;
        private final String internalClassName;
        private final String methodName;
        private final String sourceFilePath;

        private InjectedLogSite(String str, String str2, int i, String str3) {
            this.hashcode = 0;
            this.internalClassName = (String) Checks.checkNotNull(str, "class name");
            this.methodName = (String) Checks.checkNotNull(str2, "method name");
            this.encodedLineNumber = i;
            this.sourceFilePath = str3;
        }

        @Override // com.google.common.flogger.LogSite
        public String getClassName() {
            return this.internalClassName.replace('/', '.');
        }

        @Override // com.google.common.flogger.LogSite
        public String getMethodName() {
            return this.methodName;
        }

        @Override // com.google.common.flogger.LogSite
        public int getLineNumber() {
            return this.encodedLineNumber & Settings.DEFAULT_INITIAL_WINDOW_SIZE;
        }

        @Override // com.google.common.flogger.LogSite
        public String getFileName() {
            String str = this.sourceFilePath;
            if (str == null) {
                return null;
            }
            return str.substring(str.lastIndexOf(File.separatorChar) + 1);
        }

        public boolean equals(Object obj) {
            if (obj instanceof InjectedLogSite) {
                InjectedLogSite injectedLogSite = (InjectedLogSite) obj;
                if (this.methodName.equals(injectedLogSite.methodName) && this.encodedLineNumber == injectedLogSite.encodedLineNumber && internalNamesCompatible(this.internalClassName, injectedLogSite.internalClassName)) {
                    return true;
                }
            }
            return false;
        }

        private static boolean internalNamesCompatible(String str, String str2) {
            if (str == str2) {
                return true;
            }
            if (str.length() != str2.length()) {
                return false;
            }
            for (int i = 0; i < str.length(); i++) {
                char cCharAt = str.charAt(i);
                char cCharAt2 = str2.charAt(i);
                if (cCharAt != cCharAt2 && ((cCharAt & (-2)) != 46 || (cCharAt ^ cCharAt2) != 1)) {
                    return false;
                }
            }
            return true;
        }

        public int hashCode() {
            if (this.hashcode == 0) {
                this.hashcode = ((4867 + this.methodName.hashCode()) * 31) + this.encodedLineNumber;
            }
            return this.hashcode;
        }
    }
}
