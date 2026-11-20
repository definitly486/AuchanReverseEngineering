package com.google.common.flogger.util;

import androidx.core.location.LocationRequestCompat;
import java.util.function.Function;
import java.util.function.IntFunction;
import java.util.function.Predicate;
import java.util.stream.Stream;

/* JADX INFO: loaded from: classes2.dex */
final class StackWalkerStackGetter implements StackGetter {
    private static final StackWalker STACK_WALKER = StackWalker.getInstance(StackWalker.Option.SHOW_REFLECT_FRAMES);

    public StackWalkerStackGetter() {
        callerOf(StackWalkerStackGetter.class, 0);
    }

    @Override // com.google.common.flogger.util.StackGetter
    public StackTraceElement callerOf(final Class<?> cls, final int i) {
        Checks.checkArgument(i >= 0, "skipFrames must be >= 0");
        return (StackTraceElement) STACK_WALKER.walk(new Function() { // from class: com.google.common.flogger.util.StackWalkerStackGetter$$ExternalSyntheticLambda9
            @Override // java.util.function.Function
            public final Object apply(Object obj) {
                StackWalkerStackGetter stackWalkerStackGetter = this.f$0;
                return stackWalkerStackGetter.filterStackTraceAfterTarget(stackWalkerStackGetter.isTargetClass(cls), i, (Stream) obj).findFirst().orElse(null);
            }
        });
    }

    @Override // com.google.common.flogger.util.StackGetter
    public StackTraceElement[] getStackForCaller(final Class<?> cls, final int i, final int i2) {
        Checks.checkArgument(i == -1 || i > 0, "maxDepth must be > 0 or -1");
        Checks.checkArgument(i2 >= 0, "skipFrames must be >= 0");
        return (StackTraceElement[]) STACK_WALKER.walk(new Function() { // from class: com.google.common.flogger.util.StackWalkerStackGetter$$ExternalSyntheticLambda10
            @Override // java.util.function.Function
            public final Object apply(Object obj) {
                return StackWalkerStackGetter.m297$r8$lambda$6aHZrMBUxLxLKjlTfoNnLu99rY(this.f$0, cls, i2, i, (Stream) obj);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$6aHZrMBUxLxLKjl-TfoNnLu99rY, reason: not valid java name */
    public static /* synthetic */ StackTraceElement[] m297$r8$lambda$6aHZrMBUxLxLKjlTfoNnLu99rY(StackWalkerStackGetter stackWalkerStackGetter, Class cls, int i, int i2, Stream stream) {
        return (StackTraceElement[]) stackWalkerStackGetter.filterStackTraceAfterTarget(stackWalkerStackGetter.isTargetClass(cls), i, stream).limit(i2 == -1 ? LocationRequestCompat.PASSIVE_INTERVAL : i2).toArray(new IntFunction() { // from class: com.google.common.flogger.util.StackWalkerStackGetter$$ExternalSyntheticLambda6
            @Override // java.util.function.IntFunction
            public final Object apply(int i3) {
                return StackWalkerStackGetter.m298$r8$lambda$nuePAfe5v2IRGOarsJ8LQK52Ck(i3);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$nuePAfe5v2IRGOarsJ8LQ-K52Ck, reason: not valid java name */
    public static /* synthetic */ StackTraceElement[] m298$r8$lambda$nuePAfe5v2IRGOarsJ8LQK52Ck(int i) {
        return new StackTraceElement[i];
    }

    private Predicate<StackWalker.StackFrame> isTargetClass(Class<?> cls) {
        final String name = cls.getName();
        return new Predicate() { // from class: com.google.common.flogger.util.StackWalkerStackGetter$$ExternalSyntheticLambda8
            @Override // java.util.function.Predicate
            public final boolean test(Object obj) {
                return ((StackWalker.StackFrame) obj).getClassName().equals(name);
            }
        };
    }

    private Stream<StackTraceElement> filterStackTraceAfterTarget(Predicate<StackWalker.StackFrame> predicate, int i, Stream<StackWalker.StackFrame> stream) {
        return stream.skip(i + 1).dropWhile(predicate.negate()).dropWhile(predicate).map(new Function() { // from class: com.google.common.flogger.util.StackWalkerStackGetter$$ExternalSyntheticLambda7
            @Override // java.util.function.Function
            public final Object apply(Object obj) {
                return ((StackWalker.StackFrame) obj).toStackTraceElement();
            }
        });
    }
}
