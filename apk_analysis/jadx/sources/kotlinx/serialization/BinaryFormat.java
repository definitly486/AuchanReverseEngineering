package kotlinx.serialization;

/* JADX INFO: compiled from: SerialFormat.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface BinaryFormat extends SerialFormat {
    Object decodeFromByteArray(DeserializationStrategy deserializationStrategy, byte[] bArr);

    byte[] encodeToByteArray(SerializationStrategy serializationStrategy, Object obj);
}
