.class final Lcom/google/common/flogger/context/ContextMetadata$ImmutableScopeMetadata;
.super Lcom/google/common/flogger/context/ContextMetadata;
.source "ContextMetadata.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/context/ContextMetadata;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "ImmutableScopeMetadata"
.end annotation


# instance fields
.field private final entries:[Lcom/google/common/flogger/context/ContextMetadata$Entry;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "[",
            "Lcom/google/common/flogger/context/ContextMetadata$Entry<",
            "*>;"
        }
    .end annotation
.end field


# direct methods
.method constructor <init>([Lcom/google/common/flogger/context/ContextMetadata$Entry;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "([",
            "Lcom/google/common/flogger/context/ContextMetadata$Entry<",
            "*>;)V"
        }
    .end annotation

    const/4 v0, 0x0

    .line 125
    invoke-direct {p0, v0}, Lcom/google/common/flogger/context/ContextMetadata;-><init>(Lcom/google/common/flogger/context/ContextMetadata$1;)V

    .line 126
    iput-object p1, p0, Lcom/google/common/flogger/context/ContextMetadata$ImmutableScopeMetadata;->entries:[Lcom/google/common/flogger/context/ContextMetadata$Entry;

    return-void
.end method


# virtual methods
.method public concatenate(Lcom/google/common/flogger/context/ContextMetadata;)Lcom/google/common/flogger/context/ContextMetadata;
    .locals 5

    .line 154
    invoke-virtual {p1}, Lcom/google/common/flogger/backend/Metadata;->size()I

    move-result v0

    if-nez v0, :cond_0

    return-object p0

    .line 158
    :cond_0
    iget-object v1, p0, Lcom/google/common/flogger/context/ContextMetadata$ImmutableScopeMetadata;->entries:[Lcom/google/common/flogger/context/ContextMetadata$Entry;

    array-length v2, v1

    if-nez v2, :cond_1

    return-object p1

    .line 161
    :cond_1
    array-length v2, v1

    add-int/2addr v2, v0

    invoke-static {v1, v2}, Ljava/util/Arrays;->copyOf([Ljava/lang/Object;I)[Ljava/lang/Object;

    move-result-object v1

    check-cast v1, [Lcom/google/common/flogger/context/ContextMetadata$Entry;

    const/4 v2, 0x0

    :goto_0
    if-ge v2, v0, :cond_2

    .line 163
    iget-object v3, p0, Lcom/google/common/flogger/context/ContextMetadata$ImmutableScopeMetadata;->entries:[Lcom/google/common/flogger/context/ContextMetadata$Entry;

    array-length v3, v3

    add-int/2addr v3, v2

    invoke-virtual {p1, v2}, Lcom/google/common/flogger/context/ContextMetadata;->get(I)Lcom/google/common/flogger/context/ContextMetadata$Entry;

    move-result-object v4

    aput-object v4, v1, v3

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 165
    :cond_2
    new-instance p1, Lcom/google/common/flogger/context/ContextMetadata$ImmutableScopeMetadata;

    invoke-direct {p1, v1}, Lcom/google/common/flogger/context/ContextMetadata$ImmutableScopeMetadata;-><init>([Lcom/google/common/flogger/context/ContextMetadata$Entry;)V

    return-object p1
.end method

.method public findValue(Lcom/google/common/flogger/MetadataKey;)Ljava/lang/Object;
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<T:",
            "Ljava/lang/Object;",
            ">(",
            "Lcom/google/common/flogger/MetadataKey<",
            "TT;>;)TT;"
        }
    .end annotation

    .line 142
    invoke-virtual {p1}, Lcom/google/common/flogger/MetadataKey;->canRepeat()Z

    move-result v0

    xor-int/lit8 v0, v0, 0x1

    const-string v1, "metadata key must be single valued"

    invoke-static {v0, v1}, Lcom/google/common/flogger/util/Checks;->checkArgument(ZLjava/lang/String;)V

    .line 143
    iget-object v0, p0, Lcom/google/common/flogger/context/ContextMetadata$ImmutableScopeMetadata;->entries:[Lcom/google/common/flogger/context/ContextMetadata$Entry;

    array-length v0, v0

    add-int/lit8 v0, v0, -0x1

    :goto_0
    if-ltz v0, :cond_1

    .line 144
    iget-object v1, p0, Lcom/google/common/flogger/context/ContextMetadata$ImmutableScopeMetadata;->entries:[Lcom/google/common/flogger/context/ContextMetadata$Entry;

    aget-object v1, v1, v0

    .line 145
    iget-object v2, v1, Lcom/google/common/flogger/context/ContextMetadata$Entry;->key:Lcom/google/common/flogger/MetadataKey;

    invoke-virtual {v2, p1}, Lcom/google/common/flogger/MetadataKey;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    .line 146
    iget-object p1, v1, Lcom/google/common/flogger/context/ContextMetadata$Entry;->value:Ljava/lang/Object;

    return-object p1

    :cond_0
    add-int/lit8 v0, v0, -0x1

    goto :goto_0

    :cond_1
    const/4 p1, 0x0

    return-object p1
.end method

.method get(I)Lcom/google/common/flogger/context/ContextMetadata$Entry;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I)",
            "Lcom/google/common/flogger/context/ContextMetadata$Entry<",
            "*>;"
        }
    .end annotation

    .line 136
    iget-object v0, p0, Lcom/google/common/flogger/context/ContextMetadata$ImmutableScopeMetadata;->entries:[Lcom/google/common/flogger/context/ContextMetadata$Entry;

    aget-object p1, v0, p1

    return-object p1
.end method

.method public size()I
    .locals 1

    .line 131
    iget-object v0, p0, Lcom/google/common/flogger/context/ContextMetadata$ImmutableScopeMetadata;->entries:[Lcom/google/common/flogger/context/ContextMetadata$Entry;

    array-length v0, v0

    return v0
.end method
