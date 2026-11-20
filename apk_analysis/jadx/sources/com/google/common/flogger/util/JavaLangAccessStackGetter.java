package com.google.common.flogger.util;

import sun.misc.JavaLangAccess;
import sun.misc.SharedSecrets;

/* JADX INFO: loaded from: classes2.dex */
final class JavaLangAccessStackGetter implements StackGetter {
    private static final JavaLangAccess access = SharedSecrets.getJavaLangAccess();

    JavaLangAccessStackGetter() {
    }

    @Override // com.google.common.flogger.util.StackGetter
    public StackTraceElement callerOf(Class<?> cls, int i) {
        Checks.checkArgument(i >= 0, "skipFrames must be >= 0");
        Throwable th = new Throwable();
        int iFindCallerIndex = findCallerIndex(th, cls, i + 1);
        if (iFindCallerIndex == -1) {
            return null;
        }
        return access.getStackTraceElement(th, iFindCallerIndex);
    }

    @Override // com.google.common.flogger.util.StackGetter
    public StackTraceElement[] getStackForCaller(Class<?> cls, int i, int i2) {
        Checks.checkArgument(i == -1 || i > 0, "maxDepth must be > 0 or -1");
        Checks.checkArgument(i2 >= 0, "skipFrames must be >= 0");
        Throwable th = new Throwable();
        int iFindCallerIndex = findCallerIndex(th, cls, i2 + 1);
        if (iFindCallerIndex == -1) {
            return new StackTraceElement[0];
        }
        int stackTraceDepth = access.getStackTraceDepth(th) - iFindCallerIndex;
        if (i <= 0 || i >= stackTraceDepth) {
            i = stackTraceDepth;
        }
        StackTraceElement[] stackTraceElementArr = new StackTraceElement[i];
        for (int i3 = 0; i3 < i; i3++) {
            stackTraceElementArr[i3] = access.getStackTraceElement(th, iFindCallerIndex + i3);
        }
        return stackTraceElementArr;
    }

    private int findCallerIndex(Throwable th, Class<?> cls, int i) {
        int stackTraceDepth = access.getStackTraceDepth(th);
        String name = cls.getName();
        boolean z = false;
        while (i < stackTraceDepth) {
            if (access.getStackTraceElement(th, i).getClassName().equals(name)) {
                z = true;
            } else if (z) {
                return i;
            }
            i++;
        }
        return -1;
    }
}
