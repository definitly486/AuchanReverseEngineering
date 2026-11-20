package com.bumptech.glide.load;

import com.bumptech.glide.load.engine.Resource;

/* JADX INFO: loaded from: classes.dex */
public interface ResourceDecoder<T, Z> {
    Resource<Z> decode(T t, int i, int i2, Options options);

    boolean handles(T t, Options options);
}
