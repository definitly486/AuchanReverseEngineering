package com.bumptech.glide.load.engine;

import com.bumptech.glide.load.DataSource;
import com.bumptech.glide.load.Key;
import com.bumptech.glide.load.data.DataFetcher;
import com.bumptech.glide.load.model.ModelLoader;
import com.bumptech.glide.util.pool.GlideTrace;
import java.io.File;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
class ResourceCacheGenerator implements DataFetcherGenerator, DataFetcher.DataCallback<Object> {
    private File cacheFile;
    private final DataFetcherGenerator.FetcherReadyCallback cb;
    private ResourceCacheKey currentKey;

    /* JADX INFO: renamed from: helper, reason: collision with root package name */
    private final DecodeHelper<?> f5helper;
    private volatile ModelLoader.LoadData<?> loadData;
    private int modelLoaderIndex;
    private List<ModelLoader<File, ?>> modelLoaders;
    private int resourceClassIndex = -1;
    private int sourceIdIndex;
    private Key sourceKey;

    ResourceCacheGenerator(DecodeHelper<?> decodeHelper, DataFetcherGenerator.FetcherReadyCallback fetcherReadyCallback) {
        this.f5helper = decodeHelper;
        this.cb = fetcherReadyCallback;
    }

    @Override // com.bumptech.glide.load.engine.DataFetcherGenerator
    public boolean startNext() {
        GlideTrace.beginSection("ResourceCacheGenerator.startNext");
        try {
            List<Key> cacheKeys = this.f5helper.getCacheKeys();
            boolean z = false;
            if (cacheKeys.isEmpty()) {
                GlideTrace.endSection();
                return false;
            }
            List<Class<?>> registeredResourceClasses = this.f5helper.getRegisteredResourceClasses();
            if (registeredResourceClasses.isEmpty()) {
                if (File.class.equals(this.f5helper.getTranscodeClass())) {
                    GlideTrace.endSection();
                    return false;
                }
                throw new IllegalStateException("Failed to find any load path from " + this.f5helper.getModelClass() + " to " + this.f5helper.getTranscodeClass());
            }
            while (true) {
                if (this.modelLoaders != null && hasNextModelLoader()) {
                    this.loadData = null;
                    while (!z && hasNextModelLoader()) {
                        List<ModelLoader<File, ?>> list = this.modelLoaders;
                        int i = this.modelLoaderIndex;
                        this.modelLoaderIndex = i + 1;
                        this.loadData = list.get(i).buildLoadData(this.cacheFile, this.f5helper.getWidth(), this.f5helper.getHeight(), this.f5helper.getOptions());
                        if (this.loadData != null && this.f5helper.hasLoadPath(this.loadData.fetcher.getDataClass())) {
                            this.loadData.fetcher.loadData(this.f5helper.getPriority(), this);
                            z = true;
                        }
                    }
                    GlideTrace.endSection();
                    return z;
                }
                int i2 = this.resourceClassIndex + 1;
                this.resourceClassIndex = i2;
                if (i2 >= registeredResourceClasses.size()) {
                    int i3 = this.sourceIdIndex + 1;
                    this.sourceIdIndex = i3;
                    if (i3 >= cacheKeys.size()) {
                        GlideTrace.endSection();
                        return false;
                    }
                    this.resourceClassIndex = 0;
                }
                Key key = cacheKeys.get(this.sourceIdIndex);
                Class<?> cls = registeredResourceClasses.get(this.resourceClassIndex);
                this.currentKey = new ResourceCacheKey(this.f5helper.getArrayPool(), key, this.f5helper.getSignature(), this.f5helper.getWidth(), this.f5helper.getHeight(), this.f5helper.getTransformation(cls), cls, this.f5helper.getOptions());
                File file = this.f5helper.getDiskCache().get(this.currentKey);
                this.cacheFile = file;
                if (file != null) {
                    this.sourceKey = key;
                    this.modelLoaders = this.f5helper.getModelLoaders(file);
                    this.modelLoaderIndex = 0;
                }
            }
        } catch (Throwable th) {
            GlideTrace.endSection();
            throw th;
        }
    }

    private boolean hasNextModelLoader() {
        return this.modelLoaderIndex < this.modelLoaders.size();
    }

    @Override // com.bumptech.glide.load.engine.DataFetcherGenerator
    public void cancel() {
        ModelLoader.LoadData<?> loadData = this.loadData;
        if (loadData != null) {
            loadData.fetcher.cancel();
        }
    }

    @Override // com.bumptech.glide.load.data.DataFetcher.DataCallback
    public void onDataReady(Object obj) {
        this.cb.onDataFetcherReady(this.sourceKey, obj, this.loadData.fetcher, DataSource.RESOURCE_DISK_CACHE, this.currentKey);
    }

    @Override // com.bumptech.glide.load.data.DataFetcher.DataCallback
    public void onLoadFailed(Exception exc) {
        this.cb.onDataFetcherFailed(this.currentKey, exc, this.loadData.fetcher, DataSource.RESOURCE_DISK_CACHE);
    }
}
