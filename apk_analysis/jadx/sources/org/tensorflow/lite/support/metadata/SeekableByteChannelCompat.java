package org.tensorflow.lite.support.metadata;

import java.nio.ByteBuffer;
import java.nio.channels.Channel;

/* JADX INFO: loaded from: classes4.dex */
interface SeekableByteChannelCompat extends Channel {
    long position();

    SeekableByteChannelCompat position(long j);

    int read(ByteBuffer byteBuffer);

    long size();

    SeekableByteChannelCompat truncate(long j);

    int write(ByteBuffer byteBuffer);
}
