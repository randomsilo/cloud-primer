CREATE OR REPLACE FUNCTION trigger_set_timestamp()
RETURNS TRIGGER AS $$
BEGIN
  NEW.updated_at = NOW();
  RETURN NEW;
END;
$$ LANGUAGE plpgsql;


CREATE TABLE sentences (
    id int PRIMARY KEY,
    sentence EXT,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    completed_at TIMESTAMPTZ
);


CREATE TRIGGER set_timestamp
BEFORE UPDATE ON sentences
FOR EACH ROW
EXECUTE PROCEDURE trigger_set_timestamp();