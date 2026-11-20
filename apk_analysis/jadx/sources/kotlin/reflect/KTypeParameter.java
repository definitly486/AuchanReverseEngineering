package kotlin.reflect;

import java.util.List;

/* JADX INFO: compiled from: KTypeParameter.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface KTypeParameter extends KClassifier {
    String getName();

    List<KType> getUpperBounds();

    KVariance getVariance();

    boolean isReified();
}
