package kotlinx.serialization.encoding;

import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.descriptors.SerialDescriptor;

/* JADX INFO: compiled from: Decoding.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class DecodingKt {
    public static final <T> T decodeStructure(Decoder decoder, SerialDescriptor descriptor, Function1<? super CompositeDecoder, ? extends T> block) {
        Intrinsics.checkNotNullParameter(decoder, "<this>");
        Intrinsics.checkNotNullParameter(descriptor, "descriptor");
        Intrinsics.checkNotNullParameter(block, "block");
        CompositeDecoder compositeDecoderBeginStructure = decoder.beginStructure(descriptor);
        T tInvoke = block.invoke(compositeDecoderBeginStructure);
        compositeDecoderBeginStructure.endStructure(descriptor);
        return tInvoke;
    }
}
