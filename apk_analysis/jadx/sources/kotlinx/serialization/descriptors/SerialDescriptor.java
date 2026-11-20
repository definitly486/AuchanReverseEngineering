package kotlinx.serialization.descriptors;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.lang.annotation.Annotation;
import java.util.List;

/* JADX INFO: compiled from: SerialDescriptor.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface SerialDescriptor {
    SerialDescriptor getElementDescriptor(int i);

    String getElementName(int i);

    int getElementsCount();

    SerialKind getKind();

    String getSerialName();

    boolean isElementOptional(int i);

    default boolean isInline() {
        return false;
    }

    default boolean isNullable() {
        return false;
    }

    /* JADX INFO: compiled from: SerialDescriptor.kt */
    public static final class DefaultImpls {
        @Deprecated
        public static boolean isNullable(SerialDescriptor serialDescriptor) {
            return SerialDescriptor.super.isNullable();
        }

        @Deprecated
        public static boolean isInline(SerialDescriptor serialDescriptor) {
            return SerialDescriptor.super.isInline();
        }

        @Deprecated
        public static List<Annotation> getAnnotations(SerialDescriptor serialDescriptor) {
            return SerialDescriptor.super.getAnnotations();
        }
    }

    default List getAnnotations() {
        return CollectionsKt.emptyList();
    }
}
