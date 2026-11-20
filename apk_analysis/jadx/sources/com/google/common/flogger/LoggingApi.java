package com.google.common.flogger;

import com.google.common.flogger.LoggingApi;
import com.google.common.flogger.util.Checks;
import java.util.concurrent.TimeUnit;

/* JADX INFO: loaded from: classes2.dex */
public interface LoggingApi<API extends LoggingApi<API>> {
    API atMostEvery(int i, TimeUnit timeUnit);

    API every(int i);

    boolean isEnabled();

    void log();

    void log(String str);

    void log(String str, byte b);

    void log(String str, byte b, byte b2);

    void log(String str, byte b, char c);

    void log(String str, byte b, double d);

    void log(String str, byte b, float f);

    void log(String str, byte b, int i);

    void log(String str, byte b, long j);

    void log(String str, byte b, Object obj);

    void log(String str, byte b, short s);

    void log(String str, byte b, boolean z);

    void log(String str, char c);

    void log(String str, char c, byte b);

    void log(String str, char c, char c2);

    void log(String str, char c, double d);

    void log(String str, char c, float f);

    void log(String str, char c, int i);

    void log(String str, char c, long j);

    void log(String str, char c, Object obj);

    void log(String str, char c, short s);

    void log(String str, char c, boolean z);

    void log(String str, double d, byte b);

    void log(String str, double d, char c);

    void log(String str, double d, double d2);

    void log(String str, double d, float f);

    void log(String str, double d, int i);

    void log(String str, double d, long j);

    void log(String str, double d, Object obj);

    void log(String str, double d, short s);

    void log(String str, double d, boolean z);

    void log(String str, float f, byte b);

    void log(String str, float f, char c);

    void log(String str, float f, double d);

    void log(String str, float f, float f2);

    void log(String str, float f, int i);

    void log(String str, float f, long j);

    void log(String str, float f, Object obj);

    void log(String str, float f, short s);

    void log(String str, float f, boolean z);

    void log(String str, int i);

    void log(String str, int i, byte b);

    void log(String str, int i, char c);

    void log(String str, int i, double d);

    void log(String str, int i, float f);

    void log(String str, int i, int i2);

    void log(String str, int i, long j);

    void log(String str, int i, Object obj);

    void log(String str, int i, short s);

    void log(String str, int i, boolean z);

    void log(String str, long j);

    void log(String str, long j, byte b);

    void log(String str, long j, char c);

    void log(String str, long j, double d);

    void log(String str, long j, float f);

    void log(String str, long j, int i);

    void log(String str, long j, long j2);

    void log(String str, long j, Object obj);

    void log(String str, long j, short s);

    void log(String str, long j, boolean z);

    void log(String str, Object obj);

    void log(String str, Object obj, byte b);

    void log(String str, Object obj, char c);

    void log(String str, Object obj, double d);

    void log(String str, Object obj, float f);

    void log(String str, Object obj, int i);

    void log(String str, Object obj, long j);

    void log(String str, Object obj, Object obj2);

    void log(String str, Object obj, Object obj2, Object obj3);

    void log(String str, Object obj, Object obj2, Object obj3, Object obj4);

    void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5);

    void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6);

    void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7);

    void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8);

    void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8, Object obj9);

    void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8, Object obj9, Object obj10);

    void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8, Object obj9, Object obj10, Object... objArr);

    void log(String str, Object obj, short s);

    void log(String str, Object obj, boolean z);

    void log(String str, short s);

    void log(String str, short s, byte b);

    void log(String str, short s, char c);

    void log(String str, short s, double d);

    void log(String str, short s, float f);

    void log(String str, short s, int i);

    void log(String str, short s, long j);

    void log(String str, short s, Object obj);

    void log(String str, short s, short s2);

    void log(String str, short s, boolean z);

    void log(String str, boolean z, byte b);

    void log(String str, boolean z, char c);

    void log(String str, boolean z, double d);

    void log(String str, boolean z, float f);

    void log(String str, boolean z, int i);

    void log(String str, boolean z, long j);

    void log(String str, boolean z, Object obj);

    void log(String str, boolean z, short s);

    void log(String str, boolean z, boolean z2);

    void logVarargs(String str, Object[] objArr);

    API onAverageEvery(int i);

    API per(LoggingScopeProvider loggingScopeProvider);

    API per(Enum<?> r1);

    <T> API per(T t, LogPerBucketingStrategy<? super T> logPerBucketingStrategy);

    API with(MetadataKey<Boolean> metadataKey);

    <T> API with(MetadataKey<T> metadataKey, T t);

    API withCause(Throwable th);

    API withInjectedLogSite(LogSite logSite);

    API withInjectedLogSite(String str, String str2, int i, String str3);

    API withStackTrace(StackSize stackSize);

    public static class NoOp<API extends LoggingApi<API>> implements LoggingApi<API> {
        @Override // com.google.common.flogger.LoggingApi
        public final boolean isEnabled() {
            return false;
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log() {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, byte b) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, byte b, byte b2) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, byte b, char c) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, byte b, double d) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, byte b, float f) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, byte b, int i) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, byte b, long j) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, byte b, Object obj) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, byte b, short s) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, byte b, boolean z) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, char c) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, char c, byte b) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, char c, char c2) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, char c, double d) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, char c, float f) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, char c, int i) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, char c, long j) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, char c, Object obj) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, char c, short s) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, char c, boolean z) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, double d, byte b) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, double d, char c) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, double d, double d2) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, double d, float f) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, double d, int i) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, double d, long j) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, double d, Object obj) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, double d, short s) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, double d, boolean z) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, float f, byte b) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, float f, char c) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, float f, double d) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, float f, float f2) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, float f, int i) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, float f, long j) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, float f, Object obj) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, float f, short s) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, float f, boolean z) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, int i) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, int i, byte b) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, int i, char c) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, int i, double d) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, int i, float f) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, int i, int i2) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, int i, long j) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, int i, Object obj) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, int i, short s) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, int i, boolean z) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, long j) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, long j, byte b) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, long j, char c) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, long j, double d) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, long j, float f) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, long j, int i) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, long j, long j2) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, long j, Object obj) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, long j, short s) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, long j, boolean z) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, byte b) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, char c) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, double d) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, float f) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, int i) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, long j) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, Object obj2) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, Object obj2, Object obj3) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8, Object obj9) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8, Object obj9, Object obj10) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8, Object obj9, Object obj10, Object... objArr) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, short s) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, Object obj, boolean z) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, short s) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, short s, byte b) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, short s, char c) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, short s, double d) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, short s, float f) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, short s, int i) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, short s, long j) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, short s, Object obj) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, short s, short s2) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, short s, boolean z) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, boolean z, byte b) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, boolean z, char c) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, boolean z, double d) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, boolean z, float f) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, boolean z, int i) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, boolean z, long j) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, boolean z, Object obj) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, boolean z, short s) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void log(String str, boolean z, boolean z2) {
        }

        @Override // com.google.common.flogger.LoggingApi
        public final void logVarargs(String str, Object[] objArr) {
        }

        protected final API noOp() {
            return this;
        }

        @Override // com.google.common.flogger.LoggingApi
        public API withInjectedLogSite(LogSite logSite) {
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public API withInjectedLogSite(String str, String str2, int i, String str3) {
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public final <T> API with(MetadataKey<T> metadataKey, T t) {
            Checks.checkNotNull(metadataKey, "metadata key");
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public final API with(MetadataKey<Boolean> metadataKey) {
            Checks.checkNotNull(metadataKey, "metadata key");
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public <T> API per(T t, LogPerBucketingStrategy<? super T> logPerBucketingStrategy) {
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public API per(Enum<?> r1) {
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public API per(LoggingScopeProvider loggingScopeProvider) {
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public final API withCause(Throwable th) {
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public final API every(int i) {
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public final API onAverageEvery(int i) {
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public final API atMostEvery(int i, TimeUnit timeUnit) {
            Checks.checkNotNull(timeUnit, "time unit");
            return (API) noOp();
        }

        @Override // com.google.common.flogger.LoggingApi
        public API withStackTrace(StackSize stackSize) {
            Checks.checkNotNull(stackSize, "stack size");
            return (API) noOp();
        }
    }
}
