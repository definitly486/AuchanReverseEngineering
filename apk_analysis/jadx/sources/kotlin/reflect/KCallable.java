package kotlin.reflect;

import java.util.List;
import java.util.Map;

/* JADX INFO: compiled from: KCallable.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface KCallable<R> extends KAnnotatedElement {
    R call(Object... objArr);

    R callBy(Map<KParameter, ? extends Object> map);

    String getName();

    List<KParameter> getParameters();

    KType getReturnType();

    List<KTypeParameter> getTypeParameters();

    KVisibility getVisibility();

    boolean isAbstract();

    boolean isFinal();

    boolean isOpen();

    boolean isSuspend();
}
