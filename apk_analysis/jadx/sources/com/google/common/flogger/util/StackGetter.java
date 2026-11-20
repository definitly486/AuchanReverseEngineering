package com.google.common.flogger.util;

/* JADX INFO: loaded from: classes2.dex */
interface StackGetter {
    StackTraceElement callerOf(Class<?> cls, int i);

    StackTraceElement[] getStackForCaller(Class<?> cls, int i, int i2);
}
