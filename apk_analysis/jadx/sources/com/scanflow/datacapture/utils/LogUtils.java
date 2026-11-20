package com.scanflow.datacapture.utils;

import android.util.Log;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.util.Arrays;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.StringCompanionObject;

/* JADX INFO: loaded from: classes3.dex */
public final class LogUtils {
    public static final int ASSERT = 7;
    public static final int DEBUG = 3;
    public static final int ERROR = 6;
    public static final int INFO = 4;
    public static final int PRINTLN = 1;
    public static final String TAG = "LogUtils";
    public static final String TAG_FORMAT = "%s.%s(%s:%d)";
    public static final int VERBOSE = 2;
    public static final String VERTICAL = "|";
    public static final int WARN = 5;
    public static final Companion Companion = new Companion(null);
    private static boolean isShowLog = true;
    private static int priority = 1;

    public static final class Companion {
        private Companion() {
        }

        private final String generateTag(StackTraceElement stackTraceElement) {
            String className = stackTraceElement.getClassName();
            Intrinsics.checkNotNull(className);
            Intrinsics.checkNotNull(className);
            String strSubstring = className.substring(StringsKt.lastIndexOf$default((CharSequence) className, ".", 0, false, 6, (Object) null) + 1);
            Intrinsics.checkNotNullExpressionValue(strSubstring, "substring(...)");
            StringCompanionObject stringCompanionObject = StringCompanionObject.INSTANCE;
            String str = String.format(LogUtils.TAG_FORMAT, Arrays.copyOf(new Object[]{strSubstring, stackTraceElement.getMethodName(), stackTraceElement.getFileName(), Integer.valueOf(stackTraceElement.getLineNumber())}, 4));
            Intrinsics.checkNotNullExpressionValue(str, "format(...)");
            String strConcat = "LogUtils|".concat(str);
            Intrinsics.checkNotNullExpressionValue(strConcat, "toString(...)");
            return strConcat;
        }

        private final String getCallerStackLogTag() {
            return generateTag(getStackTraceElement(5));
        }

        private final String getStackTraceString(Throwable th) {
            String stackTraceString = Log.getStackTraceString(th);
            Intrinsics.checkNotNullExpressionValue(stackTraceString, "getStackTraceString(...)");
            return stackTraceString;
        }

        public final void d(String msg) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 3) {
                return;
            }
            Log.d(getCallerStackLogTag(), msg);
        }

        public final void e(String msg) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 6) {
                return;
            }
            Log.e(getCallerStackLogTag(), msg);
        }

        public final int getPriority() {
            return LogUtils.priority;
        }

        public final StackTraceElement getStackTraceElement(int i) {
            StackTraceElement stackTraceElement = Thread.currentThread().getStackTrace()[i];
            Intrinsics.checkNotNullExpressionValue(stackTraceElement, "get(...)");
            return stackTraceElement;
        }

        public final void i(String msg) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 4) {
                return;
            }
            Log.i(getCallerStackLogTag(), msg);
        }

        public final boolean isShowLog() {
            return LogUtils.isShowLog;
        }

        public final void print(Object obj) {
            if (!isShowLog() || getPriority() > 1) {
                return;
            }
            print(obj);
        }

        public final void printf(String str) {
            if (!isShowLog() || getPriority() > 1) {
                return;
            }
            System.out.printf(str, new Object[0]);
        }

        public final void println(Object obj) {
            if (!isShowLog() || getPriority() > 1) {
                return;
            }
            println(obj);
        }

        public final void setPriority(int i) {
            LogUtils.priority = i;
        }

        public final void setShowLog(boolean z) {
            LogUtils.isShowLog = z;
        }

        public final void v(String msg) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 2) {
                return;
            }
            Log.v(getCallerStackLogTag(), msg);
        }

        public final void w(String msg) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 5) {
                return;
            }
            Log.w(getCallerStackLogTag(), msg);
        }

        public final void wtf(String msg) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 7) {
                return;
            }
            Log.wtf(getCallerStackLogTag(), msg);
        }

        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        public final void d(String msg, Throwable th) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 3) {
                return;
            }
            Log.d(getCallerStackLogTag(), msg, th);
        }

        public final void e(String msg, Throwable th) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 6) {
                return;
            }
            Log.e(getCallerStackLogTag(), msg, th);
        }

        public final void i(String msg, Throwable th) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 4) {
                return;
            }
            Log.i(getCallerStackLogTag(), msg, th);
        }

        public final void print(String str) {
            if (!isShowLog() || getPriority() > 1) {
                return;
            }
            print(str);
        }

        public final void println(String str) {
            if (!isShowLog() || getPriority() > 1) {
                return;
            }
            println(str);
        }

        public final void v(String msg, Throwable th) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 2) {
                return;
            }
            Log.v(getCallerStackLogTag(), msg, th);
        }

        public final void w(String msg, Throwable th) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 5) {
                return;
            }
            Log.w(getCallerStackLogTag(), msg, th);
        }

        public final void wtf(String msg, Throwable th) {
            Intrinsics.checkNotNullParameter(msg, "msg");
            if (!isShowLog() || getPriority() > 7) {
                return;
            }
            Log.wtf(getCallerStackLogTag(), msg, th);
        }

        public final void d(Throwable t) {
            Intrinsics.checkNotNullParameter(t, "t");
            if (!isShowLog() || getPriority() > 3) {
                return;
            }
            Log.d(getCallerStackLogTag(), getStackTraceString(t));
        }

        public final void e(Throwable t) {
            Intrinsics.checkNotNullParameter(t, "t");
            if (!isShowLog() || getPriority() > 6) {
                return;
            }
            Log.e(getCallerStackLogTag(), getStackTraceString(t));
        }

        public final void i(Throwable t) {
            Intrinsics.checkNotNullParameter(t, "t");
            if (!isShowLog() || getPriority() > 4) {
                return;
            }
            Log.i(getCallerStackLogTag(), getStackTraceString(t));
        }

        public final void v(Throwable t) {
            Intrinsics.checkNotNullParameter(t, "t");
            if (!isShowLog() || getPriority() > 2) {
                return;
            }
            Log.v(getCallerStackLogTag(), getStackTraceString(t));
        }

        public final void w(Throwable t) {
            Intrinsics.checkNotNullParameter(t, "t");
            if (!isShowLog() || getPriority() > 5) {
                return;
            }
            Log.w(getCallerStackLogTag(), getStackTraceString(t));
        }

        public final void wtf(Throwable t) {
            Intrinsics.checkNotNullParameter(t, "t");
            if (!isShowLog() || getPriority() > 7) {
                return;
            }
            Log.wtf(getCallerStackLogTag(), getStackTraceString(t));
        }
    }

    private LogUtils() {
        throw new AssertionError();
    }
}
